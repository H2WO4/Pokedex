using System.Diagnostics.CodeAnalysis;
using System.Text;
using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Events;

namespace Pokedex.Models
{
	public class Pokemon : I_Battler
	{
		private const int N_SEGMENTS = 25;

		#region Variables
		private PokeMove?[] _moves;
		private I_Player? _owner;
		private int _currHP;
		private Nature _nature;

		private char[] _nMarks;
		#endregion

		#region Class Variables
		private static readonly Nature[] Natures =
			((Nature[])Enum.GetValues(typeof(Nature)))
				.Where(nature => Math.Log2((int)nature) % 1 != 0)
				.ToArray();

		private static readonly Dictionary<int, double> StageMult = new()
		{
				{ -6, 2d/8 },
				{ -5, 2d/7 },
				{ -4, 2d/6 },
				{ -3, 2d/5 },
				{ -2, 2d/4 },
				{ -1, 2d/3 },

				{  0, 2d/2 },

				{ +1, 3d/2 },
				{ +2, 4d/2 },
				{ +3, 5d/2 },
				{ +4, 6d/2 },
				{ +5, 7d/2 },
				{ +6, 8d/2 },
			};
		#endregion

		#region Properties
		public int ID => Species.ID;

		public List<PokeType> Types => Ability.ChangeType() ?? Species.Types;

		public PokeMove?[] Moves => _moves;

		public I_Player Owner
		{
			get => _owner ?? throw new InvalidOperationException("Pokemon does not have an owner");
			set => _owner = value;
		}

		public I_Combat Arena => Owner.Arena;

		public string Name { get; set; }

		/// <summary>
		/// The level the Pokemon is at [1-100]
		/// </summary>
		public int Level { get; private set; }

		/// <summary>
		/// Random stat bonuses [0-31] determined at birth
		/// </summary>
		public Dictionary<Stat, int> IVs { get; private set; }

		/// <summary>
		/// User-defined stat bonuses [0-252], totaling 510
		/// </summary>
		public Dictionary<Stat, int> EVs { get; private set; }

		/// <summary>
		/// The levels of boosts associated to each stat
		/// </summary>
		public Dictionary<Stat, int> StatBoosts { get; private set; }

		/// <summary>
		/// The nature of the Pokemon
		/// </summary>
		/// <exception cref="ArgumentException">Throws if value is non-valid</exception>
		public Nature Nature
		{
			get => _nature;
			set
			{	
				if (Math.Log2((int)value) % 1 == 0) throw new ArgumentException("Invalid value");
				_nature = value;
				_nMarks = GetNatureChars();
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

		private int BaseHP => Species.Stats[Stat.HP];
		private int BaseAtk => Species.Stats[Stat.Atk];
		private int BaseDef => Species.Stats[Stat.Def];
		private int BaseSpAtk => Species.Stats[Stat.SpAtk];
		private int BaseSpDef => Species.Stats[Stat.SpDef];
		private int BaseSpd => Species.Stats[Stat.Spd];

		/// <summary>
		/// The species the battler belongs to
		/// </summary>
		public PokeSpecies Species { get; }

		/// <inheritdoc cref="PokeSpecies.Name"/>
		public string SpeciesName => Species.Name;

		/// <inheritdoc cref="PokeSpecies.Genus"/>
		public string Genus => Species.Genus;

		/// <inheritdoc cref="PokeSpecies.Class"/>
		public PokeClass Class => Species.Class;

		/// <inheritdoc cref="PokeSpecies.Height"/>
		public int Height => Species.Height;

		/// <inheritdoc cref="PokeSpecies.Weight"/>
		public int Weight => Species.Weight;
		#endregion

		#region Constructors
		public Pokemon
		(
			PokeSpecies species,
			int level
		)
		{
			Species = species;
			Name = species.Name;

			if (level is >= 1 and <= 100)
				Level = level;
			else throw new ArgumentException("Level must be between 1-100");

			IVs = new Dictionary<Stat, int>
			{
				{Stat.HP, Program.Rnd.Next(0, 32)},
				{Stat.Atk, Program.Rnd.Next(0, 32)},
				{Stat.Def, Program.Rnd.Next(0, 32)},
				{Stat.SpAtk, Program.Rnd.Next(0, 32)},
				{Stat.SpDef, Program.Rnd.Next(0, 32)},
				{Stat.Spd, Program.Rnd.Next(0, 32)},
			};

			EVs = new Dictionary<Stat, int>
			{
				{Stat.HP, 0},
				{Stat.Atk, 0},
				{Stat.Def, 0},
				{Stat.SpAtk, 0},
				{Stat.SpDef, 0},
				{Stat.Spd, 0},
			};

			_nature = Natures[Program.Rnd.Next(Natures.Length - 1)];
			_nMarks = GetNatureChars();

			SetMoves(null, null, null, null);
			SetBoosts(0, 0, 0, 0, 0);

			Ability = new Abilities.Ability();

			_currHP = HP();
		}

		public Pokemon
		(
			PokeSpecies species,
			int level,
			string nickname
		) : this(species, level)
		{
			if (nickname != "")
				Name = nickname;
			else throw new ArgumentException("Nickname must not be empty");
		}
		
		public Pokemon
		(
			PokeSpecies species,
			int level,
			string nickname,
			Nature nature
		) : this(species, level, nickname)
		{
			_nature = nature;
			_nMarks = GetNatureChars();

			_currHP = HP();
		}
		
		public Pokemon
		(
			PokeSpecies species,
			int level,
			string nickname,
			Nature nature,
			Dictionary<Stat, int> evs
		) : this(species, level, nickname, nature)
		{
			SetEVs(evs[Stat.HP], evs[Stat.Atk], evs[Stat.Def], evs[Stat.SpAtk], evs[Stat.SpDef], evs[Stat.Spd]);

			_currHP = HP();
		}
		#endregion

		#region Methods
		public int HP()
		{
			var result = BaseHP * 2; // Base stat
			result += IVs[Stat.HP]; // IVs
			result += (int)(EVs[Stat.HP] / 4d); // EVs
			result = (int)(result * Level / 100d); // Adjust for level part 1
			result += Level + 10; // Adjust for level part 2

			result = Ability.ChangeHP(result);

			return result;
		}
		
		public int Atk()
		{
			int result = BaseAtk * 2; // Base stat
			result += IVs[Stat.Atk]; // IVs
			result += (int)(EVs[Stat.Atk] / 4d); // EVs
			result = (int)(result * Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (_nature.HasFlag(Nature.PlusAtk) ? .1 : 0) // Increasing Nature
				- (_nature.HasFlag(Nature.MinusAtk) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * StageMult[StatBoosts[Stat.Atk]]); // Apply stat boost

			result = Ability.ChangeAtk(result);

			return result;
		}
		
		public int Def()
		{
			int result = BaseDef * 2; // Base stat
			result += IVs[Stat.Def]; // IVs
			result += (int)(EVs[Stat.Def] / 4d); // EVs
			result = (int)(result * Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (_nature.HasFlag(Nature.PlusDef) ? .1 : 0) // Increasing Nature
				- (_nature.HasFlag(Nature.MinusDef) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * StageMult[(StatBoosts[Stat.Def])]); // Apply stat boost

			result = Ability.ChangeDef(result);

			return result;
		}
		
		public int SpAtk()
		{
			int result = BaseSpAtk * 2; // Base stat
			result += IVs[Stat.SpAtk]; // IVs
			result += (int)(EVs[Stat.SpAtk] / 4d); // EVs
			result = (int)(result * Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (_nature.HasFlag(Nature.PlusSpAtk) ? .1 : 0) // Increasing Nature
				- (_nature.HasFlag(Nature.MinusSpAtk) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * StageMult[(StatBoosts[Stat.SpAtk])]); // Apply stat boost

			result = Ability.ChangeSpAtk(result);

			return result;
		}
		
		public int SpDef()
		{
			int result = BaseSpDef * 2; // Base stat
			result += IVs[Stat.SpDef]; // IVs
			result += (int)(EVs[Stat.SpDef] / 4d); // EVs
			result = (int)(result * Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (_nature.HasFlag(Nature.PlusSpDef) ? .1 : 0) // Increasing Nature
				- (_nature.HasFlag(Nature.MinusSpDef) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * StageMult[(StatBoosts[Stat.SpDef])]); // Apply stat boost

			result = Ability.ChangeSpDef(result);

			return result;
		}
		
		public int Spd()
		{
			int result = BaseSpd * 2; // Base stat
			result += IVs[Stat.Spd]; // IVs
			result += (int)(EVs[Stat.Spd] / 4d); // EVs
			result = (int)(result * Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (_nature.HasFlag(Nature.PlusSpd) ? .1 : 0) // Increasing Nature
				- (_nature.HasFlag(Nature.MinusSpd) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * StageMult[(StatBoosts[Stat.Spd])]); // Apply stat boost

			result = Ability.ChangeSpd(result);

			return result;
		}

		public int GetStat(Stat stat)
			=> stat switch
			{
				Stat.HP => HP(),
				Stat.Atk => Atk(),
				Stat.Def => Def(),
				Stat.SpAtk => SpAtk(),
				Stat.SpDef => SpDef(),
				Stat.Spd => Spd(),

				_ => throw new ArgumentException("Invalid value"),
			};

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
		public void SetIVs(int hp, int atk, int def, int spAtk, int spDef, int spd)
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
			var total = EVs
				.Where(pair => pair.Key != stat)
				.Select(pair => pair.Value)
				.Aggregate((a, b) => a + b);

			if (total + val > 510)
				throw new ArgumentException("Total EVs surpass 510");
			EVs[stat] = val switch
			{
				> 252 => throw new ArgumentException("EV surpass 252"),
				< 0 => throw new ArgumentException("EV is below 0"),
				_ => val
			};
		}
		
		/// <summary>
		/// Same as SetEV, but with less checks
		/// </summary>
		/// <remarks>To be used with care</remarks>
		/// <inheritdoc cref="SetEV"/>
		private void SetEVUnsafe(Stat stat, int val)
		{
			EVs[stat] = val switch
			{
				> 252 => throw new ArgumentException("EV cannot surpass 252"),
				< 0 => throw new ArgumentException("EV cannot be negative"),
				_ => val
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
		public void SetEVs(int hp, int atk, int def, int spAtk, int spDef, int spd)
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
		[MemberNotNull(nameof(_moves))]
		public void SetMoves(PokeMove? move1, PokeMove? move2, PokeMove? move3, PokeMove? move4)
		{
			if (move1 != null) move1.Caster = this;
			if (move2 != null) move2.Caster = this;
			if (move3 != null) move3.Caster = this;
			if (move4 != null) move4.Caster = this;

			_moves = new[]
			{
				move1, move2,
				move3, move4
			};
		}

		/// <summary>
		/// Change the stat boost values to the inputs
		/// </summary>
		/// <param name="atk">The value for the Atk stat boost</param>
		/// <param name="def">The value for the Def stat boost</param>
		/// <param name="spAtk">The value for the SpAtk stat boost</param>
		/// <param name="spDef">The value for the SpDef stat boost</param>
		/// <param name="spd">The value for the Spd stat boost</param>
		[MemberNotNull(nameof(StatBoosts))]
		public void SetBoosts(int atk, int def, int spAtk, int spDef, int spd)
		{
			StatBoosts = new Dictionary<Stat, int>
			{
				{ Stat.Atk,   atk   },
				{ Stat.Def,   def   },
				{ Stat.SpAtk, spAtk },
				{ Stat.SpDef, spDef },
				{ Stat.Spd,   spd   },
			};
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
			var hpPercentBase = (int)(_currHP * 100f / HP());
			var hpPercent = hpPercentBase;
			var color = hpPercentBase switch
			{
				<= 10 => "\x1b[38;2;255;69;0m",
				<= 50 => "\x1b[38;2;255;165;0m",
				_ => "\x1b[38;2;144;238;144m"
			};
			
			// ! Change this before the end. Only works with Fira Code
			// Build the HP Bar, first segment
			var hpBar = new StringBuilder(color);
			hpBar.Append(hpPercent > 0 ? '' : '');

			hpPercent -= 4;
			// Add every full segment as needed
			var i = 0;
			while (hpPercent > 0 && i < N_SEGMENTS - 2)
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
			hpBar.Append(hpPercent > 0 ? '' : '');
			hpBar.Append("\x1b[0m");

			// * Unicode Version
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
			// hpBar.Append("\x1b[0m");
			// hpBar.Append("]");


			return hpBar.ToString();
		}

		/// <summary>
		/// Determine what suffix to put after stats in the status view
		/// </summary>
		/// <returns>The array of such prefixes</returns>
		private char[] GetNatureChars()
			=> new[]
			{
				// Atk
				_nature.HasFlag(Nature.PlusAtk) && _nature.HasFlag(Nature.MinusAtk)
				? ' '
				: _nature.HasFlag(Nature.PlusAtk)
					? '+'
					: _nature.HasFlag(Nature.MinusAtk)
						? '-'
						: ' ',
				
				// Def
				_nature.HasFlag(Nature.PlusDef) && _nature.HasFlag(Nature.MinusDef)
				? ' '
				: _nature.HasFlag(Nature.PlusDef)
					? '+'
					: _nature.HasFlag(Nature.MinusDef)
						? '-'
						: ' ',
				
				// SpAtk
				_nature.HasFlag(Nature.PlusSpAtk) && _nature.HasFlag(Nature.MinusSpAtk)
				? ' '
				: _nature.HasFlag(Nature.PlusSpAtk)
					? '+'
					: _nature.HasFlag(Nature.MinusSpAtk)
						? '-'
						: ' ',
				
				// SpDef
				_nature.HasFlag(Nature.PlusSpDef) && _nature.HasFlag(Nature.MinusSpDef)
				? ' '
				: _nature.HasFlag(Nature.PlusSpDef)
					? '+'
					: _nature.HasFlag(Nature.MinusSpDef)
						? '-'
						: ' ',
				
				// Spd
				_nature.HasFlag(Nature.PlusSpd) && _nature.HasFlag(Nature.MinusSpd)
				? ' '
				: _nature.HasFlag(Nature.PlusSpd)
					? '+'
					: _nature.HasFlag(Nature.MinusSpd)
						? '-'
						: ' ',
			};

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
		public void ChangeStatBonuses(int atk, int def, int spAtk, int spDef, int spd)
		{
			(atk, def, spAtk, spDef, spd) = Ability.OnStatChange(atk, def, spAtk, spDef, spd);

			StatBoosts = new Dictionary<Stat, int>
			{
				{ Stat.Atk, Math.Clamp(StatBoosts[Stat.Atk] + atk, -6, 6) },
				{ Stat.Def, Math.Clamp(StatBoosts[Stat.Def] + def, -6, 6) },
				{ Stat.SpAtk, Math.Clamp(StatBoosts[Stat.SpAtk] + spAtk, -6, 6) },
				{ Stat.SpDef, Math.Clamp(StatBoosts[Stat.SpDef] + spDef, -6, 6) },
				{ Stat.Spd, Math.Clamp(StatBoosts[Stat.Spd] + spd, -6, 6) },
			};
		}

		public void DoKO()
		{
			// Set HP to 0
			CurrHP = 0;

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
			status.Append($"\x1b[4m{Name}\x1b[0m");
			// Add the species
			status.AppendLine($"\x1b[2m - {SpeciesName}\x1b[0m");
			// Add the level
			status.Append($"Lvl : {Level, 3}      ");
			// Add the types
			status.AppendLine(string.Join('-', Types));
			// Add the HP
			status.AppendLine($"HP  : {GetHPBar()}");

			return status.ToString();
		}

		public string GetFullStatus()
		{
			var status = new StringBuilder();
			var statColor = new[]
			{ Stat.Atk, Stat.Def, Stat.SpAtk, Stat.SpDef, Stat.Spd }
				.Select(stat => StatBoosts[stat])
				.Select(stage => stage > 0 ? "\x1b[38;2;0;128;0m"
								: stage == 0 ? ""
								: "\x1b[38;2;255;0;0m")
				.ToArray();

			// Add the nickname
			status.Append($"\x1b[4m{Name}\x1b[0m");
			// Add the actual name, in gray
			status.AppendLine($"\x1b[2m - {SpeciesName}\x1b[0m");
			// Add the level
			status.Append($"Lvl : {Level, 3}      ");
			// Add the types
			status.AppendJoin('-', Types); status.AppendLine();
			// Add the HP
			status.AppendLine($"\x1b[1mHP\x1b[0m  : {GetHPBar()} {_currHP, 3}/{HP(), 3}");
			// Add the Atk
			status.Append($"\x1b[1mAtk\x1b[0m : {statColor[0]}{Atk(), 3}\x1b[0m{_nMarks[0]}     ");
			// Add the Def
			status.AppendLine($"\x1b[1mDef\x1b[0m : {statColor[1]}{Def(), 3}\x1b[0m{_nMarks[1]}");
			// Add the SpAtk
			status.Append($"\x1b[1mSAtk\x1b[0m: {statColor[2]}{SpAtk(), 3}\x1b[0m{_nMarks[2]}     ");
			// Add the SpDef
			status.AppendLine($"\x1b[1mSDef\x1b[0m: {statColor[3]}{SpDef(), 3}\x1b[0m{_nMarks[3]}");
			// Add the Spd
			status.Append($"\x1b[1mSpd\x1b[0m : {statColor[4]}{Spd(), 3}\x1b[0m{_nMarks[4]}");

			return status.ToString();
		}
		#endregion
	}
}