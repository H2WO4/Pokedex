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
		protected Dictionary<string, int> _ivs;
		protected Dictionary<string, int> _evs;
		protected PokemonSkill[] _moves;
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
		public PokemonSkill[] Moves { get => this._moves; }

		// Stats
		public virtual int HP { get => (int)Math.Floor((2 * this.BaseStats["hp"] + this._ivs["hp"] + Math.Floor(this._evs["hp"] / 4d)) * this._level / 100d) + this._level + 10; }
		public virtual int Atk { get => (int)((Math.Floor((2 * this.BaseStats["atk"] + this._ivs["atk"] + Math.Floor(this._evs["atk"] / 4d)) * this._level / 100d) + 5) * 1); }
		public virtual int Def { get => (int)((Math.Floor((2 * this.BaseStats["def"] + this._ivs["def"] + Math.Floor(this._evs["def"] / 4d)) * this._level / 100d) + 5) * 1); }
		public virtual int SpAtk { get => (int)((Math.Floor((2 * this.BaseStats["spAtk"] + this._ivs["spAtk"] + Math.Floor(this._evs["spAtk"] / 4d)) * this._level / 100d) + 5) * 1); }
		public virtual int SpDef { get => (int)((Math.Floor((2 * this.BaseStats["spDef"] + this._ivs["spDef"] + Math.Floor(this._evs["spDef"] / 4d)) * this._level / 100d) + 5) * 1); }
		public virtual int Spd { get => (int)((Math.Floor((2 * this.BaseStats["spd"] + this._ivs["spd"] + Math.Floor(this._evs["spd"] / 4d)) * this._level / 100d) + 5) * 1); }

		// Others
		public string PokedexEntry { get
		{
			var max = (int)Math.Floor(Math.Log10(this.Stats.Select(pair => pair.Value).Max())+1);
			return string.Join('\n', new string[]{
				$"No.  {this.ID, 4}      \"{this._nickname}\" - {this.Name}",
				$"Lvl: {this._level, 4}      " + string.Join('-', this.Types),
				$"HP : {this.HP, 4}      Atk  : {this.Atk, 4}      Def  : {this.Def, 4}",
				$"Spd: {this.Spd, 4}      S.Atk: {this.SpAtk, 4}      S.Def: {this.SpDef, 4}",
			}); }
		}
		public virtual Dictionary<string, int> Stats
		{
			get => new Dictionary<string, int>() 
			{
				{ "hp", this.HP }, { "atk", this.Atk }, { "def", this.Def },
				{ "spAtk", this.SpAtk }, { "spDef", this.SpDef }, { "spd", this.Spd },
			};
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

			var random = new Random();
			this._ivs = new Dictionary<string, int>(){
				{"hp", random.Next(0, 32)},
				{"atk", random.Next(0, 32)},
				{"def", random.Next(0, 32)},
				{"spAtk", random.Next(0, 32)},
				{"spDef", random.Next(0, 32)},
				{"spd", random.Next(0, 32)},
			};

			this._evs = new Dictionary<string, int>(){
				{"hp", 0},
				{"atk", 0},
				{"def", 0},
				{"spAtk", 0},
				{"spDef", 0},
				{"spd", 0},
			};

			this._moves = new PokemonSkill[4];
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
			Dictionary<string, int> evs
		) : this(species, level, nickname)
		{
			if (evs.Keys.SequenceEqual(new string[]{"hp", "atk", "def", "spAtk", "spDef", "spd"}))
				this._evs = evs;
			else throw new ArgumentException("EVs must be: hp, atk, def, spAtk, spDef, spd");
		}
		# endregion

		# region Methods
		public void setIV(string stat, int val) =>
			this._ivs[stat] = val;
		public void setIVs(int hp, int atk, int def, int spAtk, int spDef, int spd)
		{
			this.setIV("hp", hp);
			this.setIV("atk", atk);
			this.setIV("def", def);
			this.setIV("spAtk", spAtk);
			this.setIV("spDef", spDef);
			this.setIV("spd", spd);
		}

		public void setEV(string stat, int val)
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
		private void unsafeSetEV(string stat, int val)
		{
			if (val <= 252)
				this._evs[stat] = val;
			else throw new ArgumentException("Singular EV surpass 252");
		}

		public void setEVs(int hp, int atk, int def, int spAtk, int spDef, int spd)
		{
			if (hp + atk + def + spAtk + spDef + spd <= 510)
			{
				this.unsafeSetEV("hp", hp);
				this.unsafeSetEV("atk", atk);
				this.unsafeSetEV("def", def);
				this.unsafeSetEV("spAtk", spAtk);
				this.unsafeSetEV("spDef", spDef);
				this.unsafeSetEV("spd", spd);
			}
			else throw new ArgumentException("Total EVs surpass 510");
		}

		public void setMoves(PokemonSkill move1, PokemonSkill move2, PokemonSkill move3, PokemonSkill move4) =>
			this._moves = new PokemonSkill[4]{move1, move2, move3, move4};

		public double getAffinity(PokemonType attacker) =>
			attacker.calculateAffinity(this._species.Types);

		public override string ToString() =>
			this._nickname;
		# endregion
	}
}