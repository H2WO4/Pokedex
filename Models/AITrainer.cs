using System.Diagnostics.CodeAnalysis;
using Pokedex.Enums;
using Pokedex.Interfaces;


namespace Pokedex.Models;

/// <summary>
/// Implements an AI-controlled Player
/// </summary>
public class AITrainer : I_Player
{
    #region Variables
    private int _activeIndex;
    #endregion

    #region Properties
    public string Name { get; }

    public I_Battler Active
        => Team[_activeIndex];

    public I_Battler[ ] Team { get; }

    [NotNull]
    public I_Combat? Arena { get; set; }
    #endregion

    #region Constructors
    public AITrainer(
        string       name,
        I_Battler[ ] team
    )
    {
        Name = name;

        _activeIndex = 0;

        if (team.Length is >= 1 and <= 6)
            Team = team;
        else
            throw new ArgumentException("Team must have between 1 and 6 Pokemon.");

        Team.ToList()
            .ForEach(poke => poke.Owner = this);
    }
    #endregion

    #region Methods
    public void PlayTurn()
    {
        Active.Ability.OnTurnStart();

        I_Player opponent = Arena.Players
                                 .First(player => player != this);

        List<PokeMove> sureKill  = new(),
                       maybeKill = new();

        FindKillMove(opponent, sureKill, maybeKill);

        Active.Ability.OnTurnEnd();
    }

    private void FindKillMove(I_Player opponent, List<PokeMove> sureKill, List<PokeMove> maybeKill)
    {
        foreach (PokeMove? move in Active.Moves)
        {
            if (move is null)
                continue;

            if (move.PP == 0)
                continue;

            if (move is not I_Skill skill)
                continue;

            if (skill.CreateInfo(opponent.Active) is not DamageInfo dmgInfo)
                continue;

            var                 exceptedDamage = (int) InteractionHandler.CalculateDamage(dmgInfo, Active, opponent.Active);
            (int low, int high) hpRange        = GuessHPRange(opponent.Active.Species, opponent.Active.Level);

            if (exceptedDamage >= hpRange.high)
                sureKill.Add(move);
            else if (exceptedDamage >= hpRange.low)
                maybeKill.Add(move);
        }
    }

    private static (int low, int high) GuessHPRange(PokeSpecies species, int level)
    {
        int lowRange  = 0,
            highRange = 0;

        int median = species.Stats[Stat.HP];
        median   *= 2;
        median   += 31;
        lowRange =  highRange = median;

        highRange += 63;
        lowRange  =  (int) (lowRange  * level / 100d);
        highRange =  (int) (highRange * level / 100d);
        lowRange  += level + 10;
        highRange += level + 10;

        return (lowRange, highRange);
    }

    public void ChangeActive(int index, bool forced = false)
    {
        Console.WriteLine(forced
                              ? $"{Active} is forced out of combat!"
                              : $"{Name} takes out {Active}");

        Active.Ability.OnExit();
        Console.WriteLine();

        _activeIndex = index;

        Console.WriteLine(forced
                              ? $"{Name} sends out {Active}"
                              : $"{Active} is sent to combat!");

        Active.Ability.OnEnter();
        Console.WriteLine();
    }

    public void AskActiveChange()
    {
        // TODO
    }
    #endregion
}