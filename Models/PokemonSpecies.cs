using Pokedex.Interfaces;
using Pokedex.Enums;

namespace Pokedex.Models
{
	public abstract class PokemonSpecies : I_PokemonSpecies
	{
		# region Class Variables
		// Important infos
		protected int _id;
		protected string _name;
		protected List<PokemonType> _types = new List<PokemonType>();
		protected Dictionary<string, int> _baseStats = new Dictionary<string, int>();

		// Flavor
		protected int _generation;
		protected PokeClass _class;
		protected int _height;
		protected int _weight;
		protected string _genus;
		# endregion

		# region Properties
		// Important Infos
		public int ID { get => this._id; }
		public string Name { get => this._name; }
		public List<PokemonType> Types { get => this._types; }
		public Dictionary<string, int> Stats { get => this._baseStats; }

		// Flavor
		public int Generation { get => this._generation; }
		public string Genus { get => this._genus; }
		public PokeClass Class { get => this._class; }
		public int Height { get => this._height; }
		public int Weight { get => this._weight; }
		#endregion

		# region Constructors
		public PokemonSpecies(
			int id, string name,
			List<PokemonType> types,
			Dictionary<string, int> stats,

			int generation, string genus, PokeClass class_,
			int height,	int weight
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

		# endregion

		# region Methods
		# endregion
	}
}