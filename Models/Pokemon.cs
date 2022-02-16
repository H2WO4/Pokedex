using Pokedex.Interfaces;
using Pokedex.Enums;

namespace Pokedex.Models
{
	public abstract class Pokemon : I_Pokemon
	{
		# region Variables
		protected PokemonSpecies _species;
		protected string _nickname;
		protected int _level;
		protected int _currHP;
		protected Dictionary<string, int> _ivs;
		protected Dictionary<string, int> _evs;
		protected Nature _nature;
		protected PokemonMove?[] _moves;
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
		public Nature Nature { get => this._nature; set => this._nature = value; }
		public PokemonMove?[] Moves { get => this._moves; }

		// Stats
		public virtual int HP { get =>
			(int)Math.Floor(
				(this.BaseStats["hp"] * 2 // Base stat
				 + this._ivs["hp"] // IV
				 + Math.Floor(this._evs["hp"] / 4d) // EVs
				) * this._level / 100d // Adjust for level part 1
			) + this._level + 10; // Adjust for level part 2
		}
		public virtual int Atk { get =>
			(int)(Math.Floor(
				(Math.Floor(
					(this.BaseStats["atk"] * 2 // Base stat
					+ this._ivs["atk"] // IV
					+ Math.Floor(this._evs["atk"] / 4d) // EV
					) * this._level / 100d // Adjust for level
				) + 5) // Flat value
				*
				(1
					+ (this._nature.HasFlag(Nature.PlusAtk) ? .1 : 0) // Increasing Nature
					- (this._nature.HasFlag(Nature.MinusAtk) ? .1 : 0) // Decreasing Nature
				)
			));
		}
		public virtual int Def { get =>
			(int)(Math.Floor(
				(Math.Floor(
					(this.BaseStats["def"] * 2 // Base stat
					+ this._ivs["def"] // IV
					+ Math.Floor(this._evs["def"] / 4d) // EV
					) * this._level / 100d // Adjust for level
				) + 5) // Flat value
				*
				(1
					+ (this._nature.HasFlag(Nature.PlusDef) ? .1 : 0) // Increasing Nature
					- (this._nature.HasFlag(Nature.MinusDef) ? .1 : 0) // Decreasing Nature
				)
			));
		}
		public virtual int SpAtk { get =>
			(int)(Math.Floor(
				(Math.Floor(
					(this.BaseStats["spAtk"] * 2 // Base stat
					+ this._ivs["atk"] // IV
					+ Math.Floor(this._evs["spAtk"] / 4d) // EV
					) * this._level / 100d // Adjust for level
				) + 5) // Flat value
				*
				(1
					+ (this._nature.HasFlag(Nature.PlusSpAtk) ? .1 : 0) // Increasing Nature
					- (this._nature.HasFlag(Nature.MinusSpAtk) ? .1 : 0) // Decreasing Nature
				)
			));
		}
		public virtual int SpDef { get =>
			(int)(Math.Floor(
				(Math.Floor(
					(this.BaseStats["spDef"] * 2 // Base stat
					+ this._ivs["spDef"] // IV
					+ Math.Floor(this._evs["spDef"] / 4d) // EV
					) * this._level / 100d // Adjust for level
				) + 5) // Flat value
				*
				(1
					+ (this._nature.HasFlag(Nature.PlusSpDef) ? .1 : 0) // Increasing Nature
					- (this._nature.HasFlag(Nature.MinusSpDef) ? .1 : 0) // Decreasing Nature
				)
			));
		}
		public virtual int Spd { get =>
			(int)(Math.Floor(
				(Math.Floor(
					(this.BaseStats["spd"] * 2 // Base stat
					+ this._ivs["spd"] // IV
					+ Math.Floor(this._evs["spDef"] / 4d) // EV
					) * this._level / 100d // Adjust for level
				) + 5) // Flat value
				*
				(1
					+ (this._nature.HasFlag(Nature.PlusSpd) ? .1 : 0) // Increasing Nature
					- (this._nature.HasFlag(Nature.MinusSpd) ? .1 : 0) // Decreasing Nature
				)
			));
		}

		// Others
		public string StatusOpponent { get =>
			string.Join('\n', new string[]{
				$"\"{this._nickname}\" - {this.Name}",
				$"Lvl: {this._level, 4}      HP : {(int)this.HP / this._currHP * 100, 3}%"
			});
		}

		public string StatusAlly { get => 
			string.Join('\n', new string[]{
				$"\"{this._nickname}\" - {this.Name}",
				$"Lvl: {this._level, 4}      {this._nature, -11}      " + string.Join('-', this.Types),
				$"HP :  {this.HP, 3}/{this._currHP, 3}",
				$"Atk  : {this.Atk, 4}      Def  : {this.Def, 4}",
				$"Spd: {this.Spd, 4}      S.Atk: {this.SpAtk, 4}      S.Def: {this.SpDef, 4}",
			});
		}
		public string PokedexEntry { get =>
			string.Join('\n', new string[]{
				$"\"{this._nickname}\" - {this.Name}",
				$"No.  {this.ID, 4}      {this.Genus}",
				$"Lvl: {this._level, 4}      {this._nature, -11}      " + string.Join('-', this.Types),
				$"HP : {this.HP, 4}      Atk  : {this.Atk, 4}      Def  : {this.Def, 4}",
				$"Spd: {this.Spd, 4}      S.Atk: {this.SpAtk, 4}      S.Def: {this.SpDef, 4}",
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

			var rnd = new Random();

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

			var natures = Nature.GetValues(typeof(Nature));
			this._nature = (Nature)natures.GetValue(rnd.Next(14, natures.Length))!;

			this._moves = new PokemonMove?[]{};

			this._currHP = this.HP;
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

			this._currHP = this.HP;
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

			this._currHP = this.HP;
		}
		# endregion

		# region Methods
		public void SetIV(string stat, int val) => this._ivs[stat] = val;
		public void SetIVs(int hp, int atk, int def, int spAtk, int spDef, int spd)
		{
			this.SetIV("hp", hp);
			this.SetIV("atk", atk);
			this.SetIV("def", def);
			this.SetIV("spAtk", spAtk);
			this.SetIV("spDef", spDef);
			this.SetIV("spd", spd);
		}

		public void SetEV(string stat, int val)
		{
			var total = this._evs.Where(pair => pair.Key != stat)
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

		public void SetMoves(PokemonMove? move1, PokemonMove? move2, PokemonMove? move3, PokemonMove? move4)
		{
			this._moves = new PokemonMove?[]
			{
				move1, move2,
				move3, move4	
			};
		}

		public double getAffinity(PokemonType attacker) =>
			attacker.CalculateAffinity(this._species.Types);

		public override string ToString() => this._nickname;
		# endregion
	}
}