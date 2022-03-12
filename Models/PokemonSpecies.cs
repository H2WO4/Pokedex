using Pokedex.Enums;

namespace Pokedex.Models
{
	public abstract class PokemonSpecies
	{
		#region Class Variables
		protected int _id;
		protected string _name;
		protected List<PokeType> _types = new List<PokeType>();
		protected Dictionary<string, int> _baseStats = new Dictionary<string, int>();

		protected int _generation;
		protected PokeClass _class;
		protected int _height;
		protected int _weight;
		protected string _genus;
		#endregion

		#region Properties
		/// <summary>
		/// ID of the Pokemon in the Pokedex
		/// </summary>
		public int ID => this._id;

		/// <summary>
		/// Name of the species the Pokemon belongs to
		/// </summary>
		public string Name => this._name;

		/// <summary>
		/// Types the Pokemon posseses
		/// </summary>
		public List<PokeType> Types => this._types;

		/// <summary>
		/// Stats at level 50
		/// </summary>
		public Dictionary<string, int> Stats => this._baseStats;

		/// <summary>
		/// Which generation was the Pokemon introduced in
		/// </summary>
		public int Generation => this._generation;

		/// <summary>
		/// What type the species is
		/// </summary>
		public string Genus => this._genus;

		/// <summary>
		/// What class the Pokemon is
		/// </summary>
		public PokeClass Class => this._class;

		/// <summary>
		/// How tall is the Pokemon
		/// </summary>
		public int Height => this._height;

		/// <summary>
		/// How much the Pokemon weights
		/// </summary>
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
	}
}