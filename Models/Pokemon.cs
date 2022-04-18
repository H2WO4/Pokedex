using System.Text;

using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Events;
using Pokedex.Utils;

namespace Pokedex.Models;

public class Pokemon : I_Battler
{
    #region Constants
    private const int N_SEGMENTS = 25;
    #endregion

    #region Variables
    private I_Player? _owner;
    private int _currHP;
    private Nature _nature;

    private readonly char[] _nMarks = new char[6];
    #endregion

    #region Class Variables
    private static readonly Nature[] Natures =
        Enum.GetValues<Nature>()
            .Where(flag => !flag.IsFlag())
            .ToArray();

    private static readonly Dictionary<int, double> StageMult =
        new()
        {
            { -6, 2d / 8 }, { -5, 2d / 7 }, { -4, 2d / 6 },
            { -3, 2d / 5 }, { -2, 2d / 4 }, { -1, 2d / 3 },
            { +0, 2d / 2 },
            { +1, 3d / 2 }, { +2, 4d / 2 }, { +3, 5d / 2 },
            { +4, 6d / 2 }, { +5, 7d / 2 }, { +6, 8d / 2 },
        };
    #endregion

    #region Properties - Combat
    public int ID
        => Species.ID;

    public IEnumerable<PokeType> Types
        => Ability.ChangeType() ?? Species.Types;

    public PokeMove?[] Moves { get; } = { null, null, null, null };

    public I_Player Owner
    {
        get => _owner ?? throw new InvalidOperationException("Pokemon does not have an owner");
        set => _owner = value;
    }

    public I_Combat Arena
        => Owner.Arena;

    public string Name { get; set; }

    /// <summary>
    /// The level the Pokemon is at [1-100]
    /// </summary>
    public int Level { get; }

    /// <summary>
    /// Random stat bonuses [0-31] determined at birth
    /// </summary>
    private Dictionary<Stat, int> IVs { get; }

    /// <summary>
    /// User-defined stat bonuses [0-252], totaling 510
    /// </summary>
    private Dictionary<Stat, int> EVs { get; }

    /// <summary>
    /// The levels of boosts associated to each stat
    /// </summary>
    public Dictionary<Stat, int> StatBoosts { get; } = new();

    /// <summary>
    /// The nature of the Pokemon
    /// </summary>
    /// <exception cref="ArgumentException">Throws if value is non-valid</exception>
    public Nature Nature
    {
        get => _nature;
        set
        {
            if (value.IsFlag())
                throw new ArgumentException("Invalid value");

            _nature = value;
            CalculateNatureChars();
        }
    }

    public Ability Ability { get; set; }

    public int CurrHP
    {
        get => _currHP;
        set
        {
            _currHP = Math.Clamp(value, 0, HP());

            if (_currHP == 0)
                DoKO();
        }
    }

    public List<StatusEffect> StatusEffects { get; } = new();
    #endregion

    #region Properties - Flavor
    /// <summary>
    /// The base HP stat of the Pokemon
    /// </summary>
    private int BaseHP
        => Species.Stats[Stat.HP];

    /// <summary>
    /// The base attack stat of the Pokemon
    /// </summary>
    private int BaseAtk
        => Species.Stats[Stat.Atk];

    /// <summary>
    /// The base defense stat of the Pokemon
    /// </summary>
    private int BaseDef
        => Species.Stats[Stat.Def];

    /// <summary>
    /// The base special attack stat of the Pokemon
    /// </summary>
    private int BaseSpAtk
        => Species.Stats[Stat.SpAtk];

    /// <summary>
    /// The base special defense stat of the Pokemon
    /// </summary>
    private int BaseSpDef
        => Species.Stats[Stat.SpDef];

    /// <summary>
    /// The base speed stat of the Pokemon
    /// </summary>
    private int BaseSpd
        => Species.Stats[Stat.Spd];

    /// <summary>
    /// The species the battler belongs to
    /// </summary>
    private PokeSpecies Species { get; }

    /// <inheritdoc cref="PokeSpecies.Name"/>
    public string SpeciesName
        => Species.Name;

    /// <inheritdoc cref="PokeSpecies.Genus"/>
    public string Genus
        => Species.Genus;

    /// <inheritdoc cref="PokeSpecies.Class"/>
    public PokeClass Class
        => Species.Class;

    /// <inheritdoc cref="PokeSpecies.Height"/>
    public int Height
        => Species.Height;

    /// <inheritdoc cref="PokeSpecies.Weight"/>
    public int Weight
        => Species.Weight;
    #endregion

    #region Constructors
    public Pokemon
    (
        PokeSpecies species,
        int level
    )
    {
        if (!species.BattleOnly)
            Species = species;
        else throw new ArgumentException("Species is a combat form, not valid for creating a pokemon");
        Name = species.Name;

        if (level is >= 1 and <= 100)
            Level = level;
        else throw new ArgumentException("Level must be between 1-100");

        IVs = new Dictionary<Stat, int>
              {
                  { Stat.HP, Program.Rnd.Next(0, 32) }, { Stat.Atk, Program.Rnd.Next(0, 32) },
                  { Stat.Def, Program.Rnd.Next(0, 32) }, { Stat.SpAtk, Program.Rnd.Next(0, 32) },
                  { Stat.SpDef, Program.Rnd.Next(0, 32) }, { Stat.Spd, Program.Rnd.Next(0, 32) },
              };

        EVs = new Dictionary<Stat, int>
              {
                  { Stat.HP, 0 }, { Stat.Atk, 0 }, { Stat.Def, 0 },
                  { Stat.SpAtk, 0 }, { Stat.SpDef, 0 }, { Stat.Spd, 0 },
              };

        _nature = Natures[Program.Rnd.Next(Natures.Length - 1)];
        CalculateNatureChars();

        Ability = new Abilities.Ability(this);
        SetBoosts(0, 0, 0, 0,
                  0);

        _currHP = HP();
    }

    public Pokemon
    (
        PokeSpecies species,
        int level,
        string name
    )
        : this(species, level)
    {
        if (name != "")
            Name = name;
        else throw new ArgumentException("Name must not be empty");
    }

    public Pokemon
    (
        PokeSpecies species,
        int level,
        string name,
        Nature nature
    )
        : this(species, level, name)
    {
        _nature = nature;
        CalculateNatureChars();

        _currHP = HP();
    }

    public Pokemon
    (
        PokeSpecies species,
        int level,
        string name,
        Nature nature,
        IReadOnlyDictionary<Stat, int> evs
    )
        : this(species, level, name, nature)
    {
        SetEVs(evs[Stat.HP], evs[Stat.Atk], evs[Stat.Def],
               evs[Stat.SpAtk], evs[Stat.SpDef], evs[Stat.Spd]);

        _currHP = HP();
    }
    #endregion

    #region Methods
    public int HP()
    {
        int result = BaseHP * 2; // Base stat
        result += IVs[Stat.HP]; // IVs
        result += (int)(EVs[Stat.HP] / 4d); // EVs
        result =  (int)(result * Level / 100d); // Adjust for level part 1
        result += Level + 10; // Adjust for level part 2

        result = Ability.ChangeHP(result);
        result = StatusEffects
           .Aggregate(result, (current, effect) => effect.ChangeHP(current));

        return result;
    }

    public int Atk()
    {
        int result = BaseAtk * 2; // Base stat
        result += IVs[Stat.Atk]; // IVs
        result += (int)(EVs[Stat.Atk] / 4d); // EVs
        result =  (int)(result * Level / 100d); // Adjust for level
        result += 5; // Flat value

        double natureBonus = 1 // Calculate Nature bonus
                           + (_nature.HasFlagUnsafe(Nature.PlusAtk)
                                  ? .1
                                  : 0) // Increasing Nature
                           - (_nature.HasFlagUnsafe(Nature.MinusAtk)
                                  ? .1
                                  : 0); // Decreasing Nature

        result = (int)(result * natureBonus); // Apply Nature

        result = (int)(result * StageMult[StatBoosts[Stat.Atk]]); // Apply stat boost

        result = Ability.ChangeAtk(result);
        result = StatusEffects
           .Aggregate(result, (current, effect) => effect.ChangeAtk(current));

        return result;
    }

    public int Def()
    {
        int result = BaseDef * 2; // Base stat
        result += IVs[Stat.Def]; // IVs
        result += (int)(EVs[Stat.Def] / 4d); // EVs
        result =  (int)(result * Level / 100d); // Adjust for level
        result += 5; // Flat value

        double natureBonus = 1 // Calculate Nature bonus
                           + (_nature.HasFlagUnsafe(Nature.PlusDef)
                                  ? .1
                                  : 0) // Increasing Nature
                           - (_nature.HasFlagUnsafe(Nature.MinusDef)
                                  ? .1
                                  : 0); // Decreasing Nature

        result = (int)(result * natureBonus); // Apply Nature

        result = (int)(result * StageMult[StatBoosts[Stat.Def]]); // Apply stat boost

        result = Ability.ChangeDef(result);
        result = StatusEffects
           .Aggregate(result, (current, effect) => effect.ChangeDef(current));

        return result;
    }

    public int SpAtk()
    {
        int result = BaseSpAtk * 2; // Base stat
        result += IVs[Stat.SpAtk]; // IVs
        result += (int)(EVs[Stat.SpAtk] / 4d); // EVs
        result =  (int)(result * Level / 100d); // Adjust for level
        result += 5; // Flat value

        double natureBonus = 1 // Calculate Nature bonus
                           + (_nature.HasFlagUnsafe(Nature.PlusSpAtk)
                                  ? .1
                                  : 0) // Increasing Nature
                           - (_nature.HasFlagUnsafe(Nature.MinusSpAtk)
                                  ? .1
                                  : 0); // Decreasing Nature

        result = (int)(result * natureBonus); // Apply Nature

        result = (int)(result * StageMult[StatBoosts[Stat.SpAtk]]); // Apply stat boost

        result = Ability.ChangeSpAtk(result);
        result = StatusEffects
           .Aggregate(result, (current, effect) => effect.ChangeSpAtk(current));

        return result;
    }

    public int SpDef()
    {
        int result = BaseSpDef * 2; // Base stat
        result += IVs[Stat.SpDef]; // IVs
        result += (int)(EVs[Stat.SpDef] / 4d); // EVs
        result =  (int)(result * Level / 100d); // Adjust for level
        result += 5; // Flat value

        double natureBonus = 1 // Calculate Nature bonus
                           + (_nature.HasFlagUnsafe(Nature.PlusSpDef)
                                  ? .1
                                  : 0) // Increasing Nature
                           - (_nature.HasFlagUnsafe(Nature.MinusSpDef)
                                  ? .1
                                  : 0); // Decreasing Nature

        result = (int)(result * natureBonus); // Apply Nature

        result = (int)(result * StageMult[StatBoosts[Stat.SpDef]]); // Apply stat boost

        result = Ability.ChangeSpDef(result);
        result = StatusEffects
           .Aggregate(result, (current, effect) => effect.ChangeSpDef(current));

        return result;
    }

    public int Spd()
    {
        int result = BaseSpd * 2; // Base stat
        result += IVs[Stat.Spd]; // IVs
        result += (int)(EVs[Stat.Spd] / 4d); // EVs
        result =  (int)(result * Level / 100d); // Adjust for level
        result += 5; // Flat value

        double natureBonus = 1 // Calculate Nature bonus
                           + (_nature.HasFlagUnsafe(Nature.PlusSpd)
                                  ? .1
                                  : 0) // Increasing Nature
                           - (_nature.HasFlagUnsafe(Nature.MinusSpd)
                                  ? .1
                                  : 0); // Decreasing Nature

        result = (int)(result * natureBonus); // Apply Nature

        result = (int)(result * StageMult[StatBoosts[Stat.Spd]]); // Apply stat boost

        result = Ability.ChangeSpd(result);
        result = StatusEffects
           .Aggregate(result, (current, effect) => effect.ChangeSpd(current));

        return result;
    }

    public int GetStat(Stat stat)
    {
        return
            stat switch
            {
                Stat.HP    => HP(),
                Stat.Atk   => Atk(),
                Stat.Def   => Def(),
                Stat.SpAtk => SpAtk(),
                Stat.SpDef => SpDef(),
                Stat.Spd   => Spd(),

                _ => throw new ArgumentException("Invalid value"),
            };
    }

    /// <summary>
    /// Set a specific IV value
    /// </summary>
    /// <param name="stat">The stat whose IV should be set</param>
    /// <param name="val">The value to set</param>
    /// <exception cref="ArgumentException">Throws if value is outside of bounds</exception>
    public void SetIV(Stat stat, int val)
    {
        if (val is > 31 or < 0)
            throw new ArgumentException("Invalid IV value");

        IVs[stat] = val;
    }

    /// <summary>
    /// Set all IVs at once
    /// </summary>
    /// <param name="hp">The value for the HP IV</param>
    /// <param name="atk">The value for the Atk IV</param>
    /// <param name="def">The value for the Def IV</param>
    /// <param name="spAtk">The value for the SpAtk IV</param>
    /// <param name="spDef">The value for the SpDef IV</param>
    /// <param name="spd">The value for the Spd IV</param>
    public void SetIVs(int hp, int atk, int def,
                       int spAtk, int spDef, int spd)
    {
        SetIV(Stat.HP, hp);
        SetIV(Stat.Atk, atk);
        SetIV(Stat.Def, def);
        SetIV(Stat.SpAtk, spAtk);
        SetIV(Stat.SpDef, spDef);
        SetIV(Stat.Spd, spd);

        // Set the HP to max, in case it was higher
        CurrHP = _currHP;
    }

    /// <summary>
    /// Set a specific EV value
    /// </summary>
    /// <param name="stat">The stat whose EV should be set</param>
    /// <param name="val">The value to set</param>
    /// <exception cref="ArgumentException">Throws if value is outside of bounds</exception>
    public void SetEV(Stat stat, int val)
    {
        int total = EVs.Where(pair => pair.Key != stat)
                       .Aggregate(0, (current, pair) => current + pair.Value);

        if (total + val > 510)
            throw new ArgumentException("Total EVs surpass 510");

        EVs[stat] =
            val switch
            {
                > 252 => throw new ArgumentException("EV surpass 252"),
                < 0   => throw new ArgumentException("EV is below 0"),
                _     => val,
            };
    }

    /// <summary>
    /// Same as SetEV, but with less checks
    /// </summary>
    /// <remarks>To be used with care</remarks>
    /// <inheritdoc cref="SetEV"/>
    private void SetEVUnsafe(Stat stat, int val)
    {
        EVs[stat] =
            val switch
            {
                > 252 => throw new ArgumentException("EV cannot surpass 252"),
                < 0   => throw new ArgumentException("EV cannot be negative"),
                _     => val,
            };
    }

    /// <summary>
    /// Set all EVs at once
    /// </summary>
    /// <param name="hp">The value for the HP EV</param>
    /// <param name="atk">The value for the Atk EV</param>
    /// <param name="def">The value for the Def EV</param>
    /// <param name="spAtk">The value for the SpAtk EV</param>
    /// <param name="spDef">The value for the SpDef EV</param>
    /// <param name="spd">The value for the Spd EV</param>
    /// <exception cref="ArgumentException">Throws if any value is outside bounds</exception>
    public void SetEVs(int hp, int atk, int def,
                       int spAtk, int spDef, int spd)
    {
        if (hp + atk + def + spAtk + spDef + spd > 510)
            throw new ArgumentException("Total EVs cannot surpass 510");

        SetEVUnsafe(Stat.HP, hp);
        SetEVUnsafe(Stat.Atk, atk);
        SetEVUnsafe(Stat.Def, def);
        SetEVUnsafe(Stat.SpAtk, spAtk);
        SetEVUnsafe(Stat.SpDef, spDef);
        SetEVUnsafe(Stat.Spd, spd);
    }

    /// <summary>
    /// Change the current moveset to the inputs
    /// </summary>
    /// <param name="move1">The move to put in slot 1</param>
    /// <param name="move2">The move to put in slot 2</param>
    /// <param name="move3">The move to put in slot 3</param>
    /// <param name="move4">The move to put in slot 4</param>
    public void SetMoves(PokeMove? move1, PokeMove? move2,
                         PokeMove? move3, PokeMove? move4)
    {
        if (move1 != null) move1.Caster = this;
        if (move2 != null) move2.Caster = this;
        if (move3 != null) move3.Caster = this;
        if (move4 != null) move4.Caster = this;

        Moves[0] = move1;
        Moves[1] = move2;
        Moves[2] = move3;
        Moves[3] = move4;
    }

    /// <summary>
    /// Change the stat boost values to the inputs
    /// </summary>
    /// <param name="atk">The value for the Atk stat boost</param>
    /// <param name="def">The value for the Def stat boost</param>
    /// <param name="spAtk">The value for the SpAtk stat boost</param>
    /// <param name="spDef">The value for the SpDef stat boost</param>
    /// <param name="spd">The value for the Spd stat boost</param>
    public void SetBoosts(int atk, int def,
                          int spAtk, int spDef, int spd)
    {
        StatBoosts[Stat.Atk]   = atk;
        StatBoosts[Stat.Def]   = def;
        StatBoosts[Stat.SpAtk] = spAtk;
        StatBoosts[Stat.SpDef] = spDef;
        StatBoosts[Stat.Spd]   = spd;
    }

    /// <summary>
    /// Calculate the damage multiplier between an attacking type and this Pokemon's types
    /// </summary>
    /// <param name="attacker">The attacking type</param>
    /// <returns>A multiplier, as a double</returns>
    public double GetAffinity(PokeType attacker)
        => attacker.CalculateAffinity(Species.Types);

    /// <summary>
    /// Handles the drawing of the HP bar
    /// </summary>
    /// <returns>String representation of the HP bar</returns>
    private string GetHPBar()
    {
        // Get the HP percentage
        var hpPercentBase = (int)(_currHP * 100d / HP());
        int hpPercent     = hpPercentBase;

        // Build the HP Bar, first segment
        var hpBar = new StringBuilder();
        hpBar.Append(hpPercent > 0
                         ? ''
                         : '');

        hpPercent -= 100 / N_SEGMENTS;
        // Add every full segment as needed
        var i = 0;
        while (hpPercent > 0
            && i < N_SEGMENTS - 2)
        {
            hpBar.Append('');
            hpPercent -= 100 / N_SEGMENTS;
            i++;
        }

        // Fills the rest with empty segments
        for (; i < N_SEGMENTS - 2; i++)
        {
            hpBar.Append('');
        }

        // Add the last segment
        hpBar.Append(hpPercent > 0
                         ? ''
                         : '');
        hpBar.Append("");

        // // Build the HP Bar, first segment
        // var hpBar = new StringBuilder("[");
        // hpBar.Append(color);

        // // Add every full segment as needed
        // var i = 0;
        // while (hpPercent > 0 && i < N_SEGMENTS)
        // {
        // 	hpBar.Append("#");
        // 	hpPercent -= 100 / N_SEGMENTS;
        // 	i++;
        // }
        // // Fills the rest with empty segments
        // for (; i < N_SEGMENTS; i++)
        // {
        // 	hpBar.Append(".");
        // }
        // // Add the last segment
        // hpBar.Append("");
        // hpBar.Append("]");


        return hpBar.ToString();
    }

    /// <summary>
    /// Determine what suffix to put after stats in the status view
    /// </summary>
    /// <returns>The array of such prefixes</returns>
    private void CalculateNatureChars()
    {
        _nMarks[0] = // Atk
            (_nature & (Nature.PlusAtk | Nature.MinusAtk)) switch
            {
                Nature.PlusAtk | Nature.MinusAtk => ' ',
                Nature.PlusAtk                   => '+',
                Nature.MinusAtk                  => '-',
                _                                => ' ',
            };
        _nMarks[1] = // Def
            (_nature & (Nature.PlusDef | Nature.MinusDef)) switch
            {
                Nature.PlusDef | Nature.MinusDef => ' ',
                Nature.PlusDef                   => '+',
                Nature.MinusDef                  => '-',
                _                                => ' ',
            };
        _nMarks[2] = // SpAtk
            (_nature & (Nature.PlusSpAtk | Nature.MinusSpAtk)) switch
            {
                Nature.PlusSpAtk | Nature.MinusSpAtk => ' ',
                Nature.PlusSpAtk                     => '+',
                Nature.MinusSpAtk                    => '-',
                _                                    => ' ',
            };
        _nMarks[3] = // SpDef
            (_nature & (Nature.PlusSpDef | Nature.MinusSpDef)) switch
            {
                Nature.PlusSpDef | Nature.MinusSpDef => ' ',
                Nature.PlusSpDef                     => '+',
                Nature.MinusSpDef                    => '-',
                _                                    => ' ',
            };
        _nMarks[4] = // Spd
            (_nature & (Nature.PlusSpd | Nature.MinusSpd)) switch
            {
                Nature.PlusSpd | Nature.MinusSpd => ' ',
                Nature.PlusSpd                   => '+',
                Nature.MinusSpd                  => '-',
                _                                => ' ',
            };
    }

    /// <summary>
    /// Add the input value to an already existing stat boost
    /// </summary>
    /// <param name="stat">The stat boost the change</param>
    /// <param name="val">The value to add</param>
    public void ChangeStatBonus(Stat stat, int val)
        => StatBoosts[stat] = Math.Clamp(StatBoosts[stat] + val, -6, 6);

    /// <summary>
    /// Add the input value to the already existing stat boosts
    /// </summary>
    public void ChangeStatBonuses(int atk, int def,
                                  int spAtk, int spDef, int spd)
    {
        (atk, def, spAtk, spDef, spd) = Ability.OnStatChange(atk, def,
                                                             spAtk, spDef, spd);

        StatBoosts[Stat.Atk]   = Math.Clamp(StatBoosts[Stat.Atk] + atk, -6, 6);
        StatBoosts[Stat.Def]   = Math.Clamp(StatBoosts[Stat.Def] + def, -6, 6);
        StatBoosts[Stat.SpAtk] = Math.Clamp(StatBoosts[Stat.SpAtk] + spAtk, -6, 6);
        StatBoosts[Stat.SpDef] = Math.Clamp(StatBoosts[Stat.SpDef] + spDef, -6, 6);
        StatBoosts[Stat.Spd]   = Math.Clamp(StatBoosts[Stat.Spd] + spd, -6, 6);
    }

    public void DoKO()
    {
        // Set HP to 0
        _currHP = 0;

        // Display that the pokemon is K.O.
        Console.WriteLine($"{Name} fainted");

        Ability.OnDeath();

        // If the trainer has some Pokemons left, ask to send another one
        if (Owner.Team.Any(poke => poke.CurrHP > 0))
        {
            // Append the switch to the event list
            var ev = new SwitchInputEvent(Owner, Arena);
            Arena.AddToBottom(ev);
        }

        Console.WriteLine();
    }

    public string GetQuickStatus()
    {
        var status = new StringBuilder();

        // Add the name
        status.Append($"{Name}");
        // Add the species
        status.AppendLine($" - {SpeciesName}");
        // Add the level
        status.Append($"Lvl : {Level,3}      ");
        // Add the types
        status.AppendLine(string.Join('-', Types));
        // Add the HP
        status.AppendLine($"HP  : {GetHPBar()}");

        return status.ToString();
    }

    public string GetFullStatus()
    {
        var status = new StringBuilder();

        // Add the nickname
        status.Append($"{Name}");
        // Add the actual name
        status.AppendLine($" - {SpeciesName}");
        // Add the level
        status.Append($"Lvl : {Level,3}      ");
        // Add the types
        status.AppendJoin('-', Types);
        status.AppendLine();
        // Add the HP
        status.AppendLine($"HP  : {GetHPBar()} {_currHP,3}/{HP(),3}");
        // Add the Atk
        status.Append($"Atk : {Atk(),3}{_nMarks[0]}     ");
        // Add the Def
        status.AppendLine($"Def : {Def(),3}{_nMarks[1]}");
        // Add the SpAtk
        status.Append($"SAtk: {SpAtk(),3}{_nMarks[2]}     ");
        // Add the SpDef
        status.AppendLine($"SDef: {SpDef(),3}{_nMarks[3]}");
        // Add the Spd
        status.Append($"Spd : {Spd(),3}{_nMarks[4]}");

        return status.ToString();
    }

    public override string ToString()
        => Name;
    #endregion
}