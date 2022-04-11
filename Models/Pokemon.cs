using System.Diagnostics.CodeAnalysis;
using System.Text;
using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.Abilities;
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
		private static Nature[] __natures =
			((Nature[])Enum.GetValues(typeof(Nature)))
				.Where(nature => Math.Log2((int)nature) % 1 != 0)
				.ToArray();

		private static Dictionary<int, double> __stageMult = new Dictionary<int, double>()
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
		public int ID => this.Species.ID;

		public List<PokeType> Types => this.Ability.ChangeType() ?? this.Species.Types;

		public PokeMove?[] Moves => this._moves;

		public I_Player Owner
		{
			get => this._owner ?? throw new InvalidOperationException("Pokemon does not have an owner");
			set => this._owner = value;
		}

		public I_Combat Arena => this.Owner.Arena;

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
		public Nature Nature
		{
			get => this._nature;
			set
			{	
				if (Math.Log2((int)value) % 1 == 0) throw new ArgumentException();
				this._nature = value;
				this._nMarks = this.GetNatureChars();
			}
		}

		public Ability Ability { get; set; }

		public virtual int CurrHP
		{
			get => this._currHP;
			set
			{
				this._currHP = Math.Clamp(value, 0, this.HP());

				if (this._currHP == 0)
					this.DoKO();
			}
		}

		protected virtual int BaseHP => this.Species.Stats[Stat.HP];
		protected virtual int BaseAtk => this.Species.Stats[Stat.Atk];
		protected virtual int BaseDef => this.Species.Stats[Stat.Def];
		protected virtual int BaseSpAtk => this.Species.Stats[Stat.SpAtk];
		protected virtual int BaseSpDef => this.Species.Stats[Stat.SpDef];
		protected virtual int BaseSpd => this.Species.Stats[Stat.Spd];

		/// <summary>
		/// The species the battler belongs to
		/// </summary>
		public PokeSpecies Species { get; }

		/// <inheritdoc cref="PokeSpecies.Name"/>
		public string SpeciesName => this.Species.Name;

		/// <inheritdoc cref="PokeSpecies.Genus"/>
		public string Genus => this.Species.Genus;

		/// <inheritdoc cref="PokeSpecies.Class"/>
		public PokeClass Class => this.Species.Class;

		/// <inheritdoc cref="PokeSpecies.Height"/>
		public int Height => this.Species.Height;

		/// <inheritdoc cref="PokeSpecies.Weight"/>
		public int Weight => this.Species.Weight;
		#endregion

		#region Constructors
		public Pokemon
		(
			PokeSpecies species,
			int level
		)
		{
			this.Species = species;
			this.Name = species.Name;

			if (level >= 1 && level <= 100)
				this.Level = level;
			else throw new ArgumentException("Level must be between 1-100");

			var rnd = Program.rnd;

			this.IVs = new Dictionary<Stat, int>(){
				{Stat.HP, rnd.Next(0, 32)},
				{Stat.Atk, rnd.Next(0, 32)},
				{Stat.Def, rnd.Next(0, 32)},
				{Stat.SpAtk, rnd.Next(0, 32)},
				{Stat.SpDef, rnd.Next(0, 32)},
				{Stat.Spd, rnd.Next(0, 32)},
			};

			this.EVs = new Dictionary<Stat, int>(){
				{Stat.HP, 0},
				{Stat.Atk, 0},
				{Stat.Def, 0},
				{Stat.SpAtk, 0},
				{Stat.SpDef, 0},
				{Stat.Spd, 0},
			};

			this._nature = __natures[rnd.Next(__natures.Length - 1)];
			this._nMarks = this.GetNatureChars();

			this.SetMoves(null, null, null, null);
			this.SetBoosts(0, 0, 0, 0, 0);

			// Ceci n'est pas un placeholder
			this.Ability = new Ability___();

			this._currHP = this.HP();
		}

		public Pokemon
		(
			PokeSpecies species,
			int level,
			string nickname
		) : this(species, level)
		{
			if (nickname != "")
				this.Name = nickname;
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
			this._nature = nature;
			this._nMarks = this.GetNatureChars();

			this._currHP = this.HP();
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
			this.SetEVs(evs[Stat.HP], evs[Stat.Atk], evs[Stat.Def], evs[Stat.SpAtk], evs[Stat.SpDef], evs[Stat.Spd]);

			this._currHP = this.HP();
		}
		#endregion

		#region Methods
		public virtual int HP()
		{
			int result = this.BaseHP * 2; // Base stat
			result += this.IVs[Stat.HP]; // IVs
			result += (int)(this.EVs[Stat.HP] / 4d); // EVs
			result = (int)(result * this.Level / 100d); // Adjust for level part 1
			result += this.Level + 10; // Adjust for level part 2

			result = this.Ability.ChangeHP(result);

			return result;
		}
		
		public virtual int Atk()
		{
			int result = this.BaseAtk * 2; // Base stat
			result += this.IVs[Stat.Atk]; // IVs
			result += (int)(this.EVs[Stat.Atk] / 4d); // EVs
			result = (int)(result * this.Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusAtk) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusAtk) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[this.StatBoosts[Stat.Atk]]); // Apply stat boost

			result = this.Ability.ChangeAtk(result);

			return result;
		}
		
		public virtual int Def()
		{
			int result = this.BaseDef * 2; // Base stat
			result += this.IVs[Stat.Def]; // IVs
			result += (int)(this.EVs[Stat.Def] / 4d); // EVs
			result = (int)(result * this.Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusDef) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusDef) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[(this.StatBoosts[Stat.Def])]); // Apply stat boost

			result = this.Ability.ChangeDef(result);

			return result;
		}
		
		public virtual int SpAtk()
		{
			int result = this.BaseSpAtk * 2; // Base stat
			result += this.IVs[Stat.SpAtk]; // IVs
			result += (int)(this.EVs[Stat.SpAtk] / 4d); // EVs
			result = (int)(result * this.Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusSpAtk) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusSpAtk) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[(this.StatBoosts[Stat.SpAtk])]); // Apply stat boost

			result = this.Ability.ChangeSpAtk(result);

			return result;
		}
		
		public virtual int SpDef()
		{
			int result = this.BaseSpDef * 2; // Base stat
			result += this.IVs[Stat.SpDef]; // IVs
			result += (int)(this.EVs[Stat.SpDef] / 4d); // EVs
			result = (int)(result * this.Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusSpDef) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusSpDef) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[(this.StatBoosts[Stat.SpDef])]); // Apply stat boost

			result = this.Ability.ChangeSpDef(result);

			return result;
		}
		
		public virtual int Spd()
		{
			int result = this.BaseSpd * 2; // Base stat
			result += this.IVs[Stat.Spd]; // IVs
			result += (int)(this.EVs[Stat.Spd] / 4d); // EVs
			result = (int)(result * this.Level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusSpd) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusSpd) ? .1 : 0); // Decreasing Nature

			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[(this.StatBoosts[Stat.Spd])]); // Apply stat boost

			result = this.Ability.ChangeSpd(result);

			return result;
		}

		public int GetStat(Stat stat)
			=> stat switch
			{
				Stat.HP => this.HP(),
				Stat.Atk => this.Atk(),
				Stat.Def => this.Def(),
				Stat.SpAtk => this.SpAtk(),
				Stat.SpDef => this.SpDef(),
				Stat.Spd => this.Spd(),

				_ => throw new ArgumentException(),
			};

		public void SetIV(Stat stat, int val)
		{
			if (val > 31 || val < 0)
				throw new ArgumentException("Invalid IV value");

			this.IVs[stat] = val;
		}
		public void SetIVs(int hp, int atk, int def, int spAtk, int spDef, int spd)
		{
			this.SetIV(Stat.HP, hp);
			this.SetIV(Stat.Atk, atk);
			this.SetIV(Stat.Def, def);
			this.SetIV(Stat.SpAtk, spAtk);
			this.SetIV(Stat.SpDef, spDef);
			this.SetIV(Stat.Spd, spd);

			// Set the HP to max, in case it was higher
			/// <see cref="CurrHP">
			this.CurrHP = this.CurrHP;
		}

		public void SetEV(Stat stat, int val)
		{
			var total = this.EVs
				.Where(pair => pair.Key != stat)
				.Select(pair => pair.Value)
				.Aggregate((a, b) => a + b);

			if (total + val > 510)
				throw new ArgumentException("Total EVs surpass 510");
			if (val > 252)
				throw new ArgumentException("EV surpass 252");
			if (val < 0)
				throw new ArgumentException("EV is below 0");
			
			this.EVs[stat] = val;
		}
		private void SetEVUnsafe(Stat stat, int val)
		{
			if (val > 252)
				throw new ArgumentException("EV cannot surpass 252");
			if (val < 0)
				throw new ArgumentException("EV cannot be negative");
			
			this.EVs[stat] = val;
		}
		public void SetEVs(int hp, int atk, int def, int spAtk, int spDef, int spd)
		{
			if (hp + atk + def + spAtk + spDef + spd > 510)
				throw new ArgumentException("Total EVs cannot surpass 510");
			
			this.SetEVUnsafe(Stat.HP, hp);
			this.SetEVUnsafe(Stat.Atk, atk);
			this.SetEVUnsafe(Stat.Def, def);
			this.SetEVUnsafe(Stat.SpAtk, spAtk);
			this.SetEVUnsafe(Stat.SpDef, spDef);
			this.SetEVUnsafe(Stat.Spd, spd);
		}

		/// <summary>
		/// Change the current moveset to the inputs
		/// </summary>
		[MemberNotNull(nameof(_moves))]
		public void SetMoves(PokeMove? move1, PokeMove? move2, PokeMove? move3, PokeMove? move4)
		{
			if (move1 != null) move1.Caster = this;
			if (move2 != null) move2.Caster = this;
			if (move3 != null) move3.Caster = this;
			if (move4 != null) move4.Caster = this;

			this._moves = new PokeMove?[]
			{
				move1, move2,
				move3, move4
			};
		}

		/// <summary>
		/// Change the stat boost values to the inputs
		/// </summary>
		[MemberNotNull(nameof(StatBoosts))]
		public void SetBoosts(int atk, int def, int spAtk, int spDef, int spd)
		{
			this.StatBoosts = new Dictionary<Stat, int>()
			{
				{ Stat.Atk,   atk   },
				{ Stat.Def,   def   },
				{ Stat.SpAtk, spAtk },
				{ Stat.SpDef, spDef },
				{ Stat.Spd,   spd   },
			};
		}

		/// <summary>
		/// Calculate the damage mutliplier between an attacking type and this Pokemon's types
		/// </summary>
		/// <param name="attacker">The attacking type</param>
		/// <returns>A multipler, as a double</returns>
		public double GetAffinity(PokeType attacker)
			=> attacker.CalculateAffinity(this.Species.Types);

		/// <summary>
		/// Handles the drawing of the HP bar
		/// </summary>
		/// <returns>String representation of the HP bar</returns>
		private string GetHPBar()
		{
			// Get the HP percentage
			var hpPercentBase = (int)(this._currHP * 100f / this.HP());
			var hpPercent = hpPercentBase;
			var color = hpPercentBase <= 10 ? "\x1b[38;2;255;69;0m"
						: hpPercentBase <= 50 ? "\x1b[38;2;255;165;0m"
						: "\x1b[38;2;144;238;144m";
			
			// ! Change this before the end. Only works with Fira Code
			// Build the HP Bar, first segment
			var hpBar = new StringBuilder(color);
			hpBar.Append(hpPercent > 0 ? "" : "");

			hpPercent -= 4;
			// Add every full segment as needed
			var i = 0;
			while (hpPercent > 0 && i < N_SEGMENTS - 2)
			{
				hpBar.Append("");
				hpPercent -= 100 / N_SEGMENTS;
				i++;
			}
			// Fills the rest with empty segments
			for (; i < N_SEGMENTS - 2; i++)
			{
				hpBar.Append("");
			}
			// Add the last segment
			hpBar.Append(hpPercent > 0 ? "" : "");
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

		private char[] GetNatureChars()
			=> this._nMarks = new char[]
			{
				// Atk
				this._nature.HasFlag(Nature.PlusAtk) && this.Nature.HasFlag(Nature.MinusAtk)
				? ' '
				: this._nature.HasFlag(Nature.PlusAtk)
					? '+'
					: this._nature.HasFlag(Nature.MinusAtk)
						? '-'
						: ' ',
				
				// Def
				this._nature.HasFlag(Nature.PlusDef) && this.Nature.HasFlag(Nature.MinusDef)
				? ' '
				: this._nature.HasFlag(Nature.PlusDef)
					? '+'
					: this._nature.HasFlag(Nature.MinusDef)
						? '-'
						: ' ',
				
				// SpAtk
				this._nature.HasFlag(Nature.PlusSpAtk) && this.Nature.HasFlag(Nature.MinusSpAtk)
				? ' '
				: this._nature.HasFlag(Nature.PlusSpAtk)
					? '+'
					: this._nature.HasFlag(Nature.MinusSpAtk)
						? '-'
						: ' ',
				
				// SpDef
				this._nature.HasFlag(Nature.PlusSpDef) && this.Nature.HasFlag(Nature.MinusSpDef)
				? ' '
				: this._nature.HasFlag(Nature.PlusSpDef)
					? '+'
					: this._nature.HasFlag(Nature.MinusSpDef)
						? '-'
						: ' ',
				
				// Spd
				this._nature.HasFlag(Nature.PlusSpd) && this.Nature.HasFlag(Nature.MinusSpd)
				? ' '
				: this._nature.HasFlag(Nature.PlusSpd)
					? '+'
					: this._nature.HasFlag(Nature.MinusSpd)
						? '-'
						: ' ',
			};

		/// <summary>
		/// Add the input value to an already existing stat boost
		/// </summary>
		/// <param name="stat">The stat boost the change</param>
		/// <param name="val">The value to add</param>
		public void ChangeStatBonus(Stat stat, int val)
			=> this.StatBoosts[stat] = Math.Clamp(this.StatBoosts[stat] + val, -6, 6);

		/// <summary>
		/// Add the input value to the already existing stat boosts
		/// </summary>
		public void ChangeStatBonuses(int atk, int def, int spAtk, int spDef, int spd)
		{
			(atk, def, spAtk, spDef, spd) = this.Ability.OnStatChange(atk, def, spAtk, spDef, spd);

			this.StatBoosts = new Dictionary<Stat, int>
			{
				{ Stat.Atk, Math.Clamp(this.StatBoosts[Stat.Atk] + atk, -6, 6) },
				{ Stat.Def, Math.Clamp(this.StatBoosts[Stat.Def] + def, -6, 6) },
				{ Stat.SpAtk, Math.Clamp(this.StatBoosts[Stat.SpAtk] + spAtk, -6, 6) },
				{ Stat.SpDef, Math.Clamp(this.StatBoosts[Stat.SpDef] + spDef, -6, 6) },
				{ Stat.Spd, Math.Clamp(this.StatBoosts[Stat.Spd] + spd, -6, 6) },
			};
		}

		public void DoKO()
		{
			// Set HP to 0
			this.CurrHP = 0;

			// Display that the pokemon is K.O.
			Console.WriteLine($"{this.Name} fainted");

			this.Ability.OnDeath();

			// If the trainer has some Pokemons left, ask to send another one
			if (this.Owner.Team.Any(poke => poke.CurrHP > 0))
			{
				// Append the switch to the event list
				var ev = new SwitchInputEvent(this.Owner, this.Arena);
				this.Arena.AddToBottom(ev);
			}

			Console.WriteLine();
		}

		public string GetQuickStatus()
		{
			var status = new StringBuilder();

			// Add the name
			status.Append($"\x1b[4m{this.Name}\x1b[0m");
			// Add the species
			status.AppendLine($"\x1b[2m - {this.SpeciesName}\x1b[0m");
			// Add the level
			status.Append($"Lvl : {this.Level, 3}      ");
			// Add the types
			status.AppendLine(string.Join('-', this.Types));
			// Add the HP
			status.AppendLine($"HP  : {this.GetHPBar()}");

			return status.ToString();
		}

		public string GetFullStatus()
		{
			var status = new StringBuilder();
			string[] statColor = new Stat[]
			{ Stat.Atk, Stat.Def, Stat.SpAtk, Stat.SpDef, Stat.Spd }
				.Select(stat => this.StatBoosts[stat])
				.Select(stage => stage > 0 ? "\x1b[38;2;0;128;0m"
								: stage == 0 ? ""
								: "\x1b[38;2;255;0;0m")
				.ToArray();

			// Add the nickname
			status.Append($"\x1b[4m{this.Name}\x1b[0m");
			// Add the actual name, in gray
			status.AppendLine($"\x1b[2m - {this.SpeciesName}\x1b[0m");
			// Add the level
			status.Append($"Lvl : {this.Level, 3}      ");
			// Add the types
			status.AppendJoin('-', this.Types); status.AppendLine();
			// Add the HP
			status.AppendLine($"\x1b[1mHP\x1b[0m  : {this.GetHPBar()} {this._currHP, 3}/{this.HP(), 3}");
			// Add the Atk
			status.Append($"\x1b[1mAtk\x1b[0m : {statColor[0]}{this.Atk(), 3}\x1b[0m{this._nMarks[0]}     ");
			// Add the Def
			status.AppendLine($"\x1b[1mDef\x1b[0m : {statColor[1]}{this.Def(), 3}\x1b[0m{this._nMarks[1]}");
			// Add the SpAtk
			status.Append($"\x1b[1mSAtk\x1b[0m: {statColor[2]}{this.SpAtk(), 3}\x1b[0m{this._nMarks[2]}     ");
			// Add the SpDef
			status.AppendLine($"\x1b[1mSDef\x1b[0m: {statColor[3]}{this.SpDef(), 3}\x1b[0m{this._nMarks[3]}");
			// Add the Spd
			status.Append($"\x1b[1mSpd\x1b[0m : {statColor[4]}{this.Spd(), 3}\x1b[0m{this._nMarks[4]}");

			return status.ToString();
		}
		#endregion
	}
}