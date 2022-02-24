using System.Drawing;
using System.Text;
using Pokedex.Interfaces;
using Pokedex.Enums;
using Pokedex.Models.Events;
using System.Diagnostics.CodeAnalysis;
using Pastel;

namespace Pokedex.Models
{
    public abstract class Pokemon : I_Pokemon
	{
		protected const int N_SEGMENTS = 25;

		# region Variables
		protected PokemonSpecies _species;
		protected string _nickname;
		protected int _level;
		protected int _currHP;
		protected Dictionary<string, int> _ivs;
		protected Dictionary<string, int> _evs;
		protected Nature _nature;
		protected PokemonMove?[] _moves;
		protected Dictionary<string, int> _statBoosts;

		protected char[] _nMarks;
		# endregion

		# region Class Variables
		protected static Nature[] __natures =
			((Nature[])Enum.GetValues(typeof(Nature)))
				.Where(nature => Math.Log2(((int)nature)) % 1 != 0)
				.ToArray();
		
		protected static Dictionary<int, double> __stageMult = new Dictionary<int, double>()
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
		# endregion

		# region Properties
		// Inherited from the Species - Important infos
		public int ID { get => this._species.ID; }
		public string Name { get => this._species.Name; }
		public PokemonSpecies Species { get => this._species; }
		public List<PokemonType> Types { get => this._species.Types; }
		public Dictionary<string, int> BaseStats { get => this._species.Stats; }

		// Inherited from the Species - Flavor
		public string Genus { get => this._species.Genus; }
		public PokeClass Class { get => this._species.Class; }
		public int Height { get => this._species.Height; }
		public int Weight { get => this._species.Weight; }


		// Unique per Pokemon
		public int Level { get => this._level; }
		public string Nickname { get => this._nickname; set => this._nickname = value; }
		public Dictionary<string, int> IVs { get => this._ivs; }
		public Dictionary<string, int> EVs { get => this._evs; }
		public Nature Nature { get => this._nature; set { this._nature = value; this._nMarks = this.GetNatureChars(); } }
		public PokemonMove?[] Moves { get => this._moves; }

		// Stats
		public virtual int BaseHP { get => this.Species.Stats["hp"]; }
		public virtual int BaseAtk { get => this.Species.Stats["atk"]; }
		public virtual int BaseDef { get => this.Species.Stats["def"]; }
		public virtual int BaseSpAtk { get => this.Species.Stats["spAtk"]; }
		public virtual int BaseSpDef { get => this.Species.Stats["spDef"]; }
		public virtual int BaseSpd { get => this.Species.Stats["spd"]; }

		public virtual int CurrHP
		{
			get => this._currHP;
			set => this._currHP = Math.Clamp(value, 0, this.HP());
		}

		// Others
		public string QuickStatus { get =>
			string.Join('\n', new string[]{
				$"\"{this._nickname}\"" + "\x1b[2m" + $" - {this.Name}" + "\x1b[0m",
				$"Lvl : {this._level, 3}      " + string.Join('-', this.Types),
				$"HP  : {this.GetHPBar()}",
			});
		}
		public string FullStatus { get
			{
				string[] colors = new string[]
				{ "atk", "def", "spAtk", "spDef", "spd" }
					.Select(stat => this._statBoosts[stat])
					.Select(stage => stage > 0 ? "\x1b[38;2;255;0;0m"
									: stage == 0 ? "\x1b[38;2;0;128;0m"
									: "\x1b[38;2;255;0;128m")
					.ToArray();

				return string.Join('\n', new string[]{
					$"\"{this._nickname}\""
					+ "\x1b[2m" + $" - {this.Name}" + "\x1b[0m",
					$"Lvl : {this._level, 3}      " + string.Join('-', this.Types),
					$"HP  : {this.GetHPBar()} {this._currHP, 3}/{this.HP(), 3}",

					$"Atk : {colors[0]}{this.Atk(), 3}\x1b[0m{this._nMarks[0]}"
					+ $"     Def : {colors[1]}{this.Def(), 3}\x1b[0m{this._nMarks[1]}",
					$"SAtk: {colors[2]}{this.SpAtk(), 3}\x1b[0m{this._nMarks[2]}"
					+ $"     SDef: {colors[3]}{this.SpDef(), 3}\x1b[0m{this._nMarks[3]}",
					$"Spd : {colors[4]}{this.Spd(), 3}\x1b[0m{this._nMarks[4]}",
				});
			}
		}
		public string PokedexEntry { get =>
			string.Join('\n', new string[]{
				$"{this.Name}",
				$"No.  {this.ID, 3}      {this.Genus}",
				$"Lvl: {this._level, 3}      " + string.Join('-', this.Types),
				$"HP : {this.BaseHP, 3}      Atk  : {this.BaseAtk, 3}      S.Atk  : {this.BaseSpAtk, 3}",
				$"Spd: {this.BaseSpd, 3}      Def  : {this.BaseDef, 3}      S.Def: {this.BaseSpDef, 3}",
			});
		}
		#endregion

		# region Constructors
		public Pokemon
		(
			PokemonSpecies species, 
			int level
		)
		{
			this._species = species;
			this._nickname = species.Name;

			if (level >= 1 && level <= 100)
				this._level = level;
			else throw new ArgumentException("Level must be between 1-100");

			var rnd = Program.rnd;

			this._ivs = new Dictionary<string, int>(){
				{"hp", rnd.Next(0, 32)},
				{"atk", rnd.Next(0, 32)},
				{"def", rnd.Next(0, 32)},
				{"spAtk", rnd.Next(0, 32)},
				{"spDef", rnd.Next(0, 32)},
				{"spd", rnd.Next(0, 32)},
			};

			this._evs = new Dictionary<string, int>(){
				{"hp", 0},
				{"atk", 0},
				{"def", 0},
				{"spAtk", 0},
				{"spDef", 0},
				{"spd", 0},
			};

			this._nature = __natures[rnd.Next(__natures.Length - 1)];
			this._nMarks = this.GetNatureChars();

			this.SetMoves(null, null, null, null);
			this.SetBoosts(0, 0, 0, 0, 0);

			this._currHP = this.HP();
		}
		public Pokemon
		(
			PokemonSpecies species,
			int level,
			string nickname
		) : this(species, level)
		{
			if (nickname != "")
				this._nickname = nickname;
			else throw new ArgumentException("Nickname must not be empty");
		}
		public Pokemon
		(
			PokemonSpecies species,
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
			PokemonSpecies species,
			int level,
			string nickname,
			Nature nature,
			Dictionary<string, int> evs
		) : this(species, level, nickname, nature)
		{
			if (evs.Keys.SequenceEqual(new string[]{"hp", "atk", "def", "spAtk", "spDef", "spd"}))
				this._evs = evs;
			else throw new ArgumentException("EVs must be: hp, atk, def, spAtk, spDef, spd");

			this._currHP = this.HP();
		}
		# endregion

		# region Methods
		public int HP()
		{
			int result = this.BaseHP * 2; // Base stat
			result += this._ivs["hp"]; // IVs
			result += (int)(this._evs["hp"] / 4d); // EVs
			result = (int)(result * this._level / 100d); // Adjust for level part 1
			result += this._level + 10; // Adjust for level part 2

			return result;
		}
		public int Atk()
		{
			int result = this.BaseAtk * 2; // Base stat
			result += this._ivs["atk"]; // IVs
			result += (int)(this._evs["atk"] / 4d); // EVs
			result = (int)(result * this._level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusAtk) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusAtk) ? .1 : 0); // Decreasing Nature
			
			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[this._statBoosts["atk"]]); // Apply stat boost

			return result;
		}
		public int Def()
		{
			int result = this.BaseDef * 2; // Base stat
			result += this._ivs["def"]; // IVs
			result += (int)(this._evs["def"] / 4d); // EVs
			result = (int)(result * this._level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusDef) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusDef) ? .1 : 0); // Decreasing Nature
			
			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[(this._statBoosts["def"])]); // Apply stat boost

			return result;
		}
		public int SpAtk()
		{
			int result = this.BaseSpAtk * 2; // Base stat
			result += this._ivs["spAtk"]; // IVs
			result += (int)(this._evs["spAtk"] / 4d); // EVs
			result = (int)(result * this._level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusSpAtk) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusSpAtk) ? .1 : 0); // Decreasing Nature
			
			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[(this._statBoosts["spAtk"])]); // Apply stat boost

			return result;
		}
		public int SpDef()
		{
			int result = this.BaseSpDef * 2; // Base stat
			result += this._ivs["spDef"]; // IVs
			result += (int)(this._evs["spDef"] / 4d); // EVs
			result = (int)(result * this._level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusSpDef) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusSpDef) ? .1 : 0); // Decreasing Nature
			
			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[(this._statBoosts["spDef"])]); // Apply stat boost

			return result;
		}
		public int Spd()
		{
			int result = this.BaseSpd * 2; // Base stat
			result += this._ivs["spd"]; // IVs
			result += (int)(this._evs["spd"] / 4d); // EVs
			result = (int)(result * this._level / 100d); // Adjust for level
			result += 5; // Flat value

			double natureBonus = 1 // Calculate Nature bonus
				+ (this._nature.HasFlag(Nature.PlusSpd) ? .1 : 0) // Increasing Nature
				- (this._nature.HasFlag(Nature.MinusSpd) ? .1 : 0); // Decreasing Nature
			
			result = (int)(result * natureBonus); // Apply Nature

			result = (int)(result * __stageMult[(this._statBoosts["spd"])]); // Apply stat boost

			return result;
		}

		public void SetIV(string stat, int val) => this._ivs[stat] = val;
		public void SetIVs(int hp, int atk, int def, int spAtk, int spDef, int spd)
		{
			this.SetIV("hp", hp);
			this.SetIV("atk", atk);
			this.SetIV("def", def);
			this.SetIV("spAtk", spAtk);
			this.SetIV("spDef", spDef);
			this.SetIV("spd", spd);

			this.CurrHP = this.CurrHP;
		}

		public void SetEV(string stat, int val)
		{
			var total = this._evs
				.Where(pair => pair.Key != stat)
				.Select(pair => pair.Value)
				.Aggregate((a, b) => a + b);
			
			if (total + val <= 510)
				if (val <= 255)
					this._evs[stat] = val;
				else throw new ArgumentException("Singular EV surpass 252");
			else throw new ArgumentException("Total EVs surpass 510");
		}
		private void SetEVUnsafe(string stat, int val)
		{
			if (val <= 252)
				this._evs[stat] = val;
			else throw new ArgumentException("Singular EV surpass 252");
		}
		public void SetEVs(int hp, int atk, int def, int spAtk, int spDef, int spd)
		{
			if (hp + atk + def + spAtk + spDef + spd <= 510)
			{
				this.SetEVUnsafe("hp", hp);
				this.SetEVUnsafe("atk", atk);
				this.SetEVUnsafe("def", def);
				this.SetEVUnsafe("spAtk", spAtk);
				this.SetEVUnsafe("spDef", spDef);
				this.SetEVUnsafe("spd", spd);
			}
			else throw new ArgumentException("Total EVs surpass 510");
		}

		[MemberNotNull(nameof(_moves))]
		public void SetMoves(PokemonMove? move1, PokemonMove? move2, PokemonMove? move3, PokemonMove? move4)
		{
			this._moves = new PokemonMove?[]
			{
				move1, move2,
				move3, move4	
			};
		}

		[MemberNotNull(nameof(_statBoosts))]
		public void SetBoosts(int atk, int def, int spAtk, int spDef, int spd)
		{
			this._statBoosts = new Dictionary<string, int>()
			{
				{ "atk",   atk   },
				{ "def",   def   },
				{ "spAtk", spAtk },
				{ "spDef", spDef },
				{ "spd",   spd   },
			};
		}

		public double GetAffinity(PokemonType attacker) =>
			attacker.CalculateAffinity(this._species.Types);

		private StringBuilder GetHPBar()
		{
			// Get the HP percentage
			var hpPercentBase = (int)(this._currHP * 100f / this.HP());
			var hpPercent = hpPercentBase;
			// ! Change this before the end. Only works with Fira Code
			// Build the HP Bar, first segment
			var hpBar = new StringBuilder(hpPercent > 0 ? "" : "");
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

			// * Unicode Version
			// // Build the HP Bar, first segment
			// var hpBar = new StringBuilder("[");
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
			// hpBar.Append("]");

			var color = hpPercentBase <= 10 ? Color.OrangeRed
						: hpPercentBase <= 50 ? Color.Orange
						: Color.LightGreen;

			return new StringBuilder(hpBar.ToString().Pastel(color));
		}

		private char[] GetNatureChars() =>
			this._nMarks = new char[]
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

        public bool ReceiveDamage(Player owner, Pokemon caster, PokemonMove move, PokemonType type, CombatInstance context)
        {
			// If this pokemon fainted, do nothing
			if (this.CurrHP == 0)
				return false;

			// * Damage Calculation
			// Initial damage
            double damage = (0.4 * caster.Level + 2) * (move.Power ?? 0);

			// Adjust for stats
			if (move.Class == MoveClass.Physical)
				damage *= ((double)caster.Atk() / this.Def());
			else
				damage *= ((double)caster.SpAtk() / this.SpDef());
			
			// Continue the calculation
			damage = damage / 50 + 2;

			// Apply weather
			damage = context.Weather.OnDamageGive(damage, move.Type);

			// Apply type weaknesses
			damage *= this.GetAffinity(type);

			// Apply STAB
			if (caster.Types.Contains(type))
				damage *= 1.5;
			
			# region TODO
			// ? Implement Burn
			// if (burn_cond && move.Class == MoveClass.Physical)
			//	damage *= 0.5;

			// ? Implement Critical Hits
			// Code

			// ? Implement abilities OnInflictDamage
			// Code

			// ? Implement abilities OnReceiveDamage
			// Code
			# endregion

			// Floor the result
			int finalDamage = (int)(damage);


			// * Output
			// Do damage and display
			this.CurrHP -= finalDamage;
			int percentage = Math.Clamp(finalDamage * 100 / this.HP(), 0, 100);
			Console.WriteLine($"{this.Nickname} lost {percentage}% HP");


			// * Fainted
			// If this pokemon fainted
			if (this.CurrHP == 0)
			{
				// Handles the KO
				this.DoKO(owner, context);
				return true;
			}

			Console.WriteLine();
			return true;
        }

		public bool ReceivePureDamage(int damage, Player owner, Pokemon caster, PokemonMove move, PokemonType type, CombatInstance context)
        {
			// If this pokemon fainted, do nothing
			if (this.CurrHP == 0)
				return false;

			// * Damage Calculation
			
			# region TODO
			// ? Implement abilities OnInflictDamage
			// Code

			// ? Implement abilities OnReceiveDamage
			// Code
			# endregion

			// * Output
			// Do damage and display
			this.CurrHP -= damage;
			int percentage = Math.Clamp(damage * 100 / this.HP(), 0, 100);
			Console.WriteLine($"{this.Nickname} lost {percentage}% HP");


			// * Fainted
			// If this pokemon fainted
			if (this.CurrHP == 0)
			{
				// Handles the KO
				this.DoKO(owner, context);
				return true;
			}

			Console.WriteLine();
			return true;
        }

		public void DoKO(Player owner, CombatInstance context)
		{
			// Set HP to 0
			this.CurrHP = 0;

			// Display that the pokemon is K.O.
			Console.WriteLine($"{this.Nickname} fainted");

			// ? Implement OnKO abilities

			// If the trainer has some Pokemons left, ask to send another one
			if (owner.Team.Any(poke => poke.CurrHP > 0))
			{
				// Append the switch to the event list
				var ev = new SwitchInputEvent(owner, context);
				context.AddToBottom(ev);
			}
			
			Console.WriteLine();
		}
        #endregion
    }
}