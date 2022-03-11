using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models
{
	public abstract class PokemonSpecies
	{
		#region Class Variables
		// Important infos
		protected int _id;
		protected string _name;
		protected List<PokeType> _types = new List<PokeType>();
		protected Dictionary<string, int> _baseStats = new Dictionary<string, int>();

		// Flavor
		protected int _generation;
		protected PokeClass _class;
		protected int _height;
		protected int _weight;
		protected string _genus;
		#endregion

		#region Properties
		// Important Infos
		public int ID => this._id;
		public string Name => this._name;
		public List<PokeType> Types => this._types;
		public Dictionary<string, int> Stats => this._baseStats;

		// Flavor
		public int Generation => this._generation;
		public string Genus => this._genus;
		public PokeClass Class => this._class;
		public int Height => this._height;
		public int Weight => this._weight;
		#endregion

		#region Constructors
		public PokemonSpecies(
			int id, string name,
			List<PokeType> types,
			Dictionary<string, int> stats,

			int generation, string genus, PokeClass class_,
			int height, int weight
		)
		{
			this._id = id;
			this._name = name;
			this._types = types;
			this._baseStats = stats;

			this._generation = generation;
			this._genus = genus;
			this._class = class_;
			this._height = height;
			this._weight = weight;
		}

		#endregion

		#region Methods
		#endregion
	}
}