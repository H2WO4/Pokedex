using Pokedex.Models.PokemonTypes;
using Pokedex.Enums;

namespace Pokedex.Models.Pokemons
{
	public class ArceusSpecies : PokeSpecies
	{
		#region Class Variables
		private static ArceusSpecies? _singleton;
		#endregion

		#region Properties
		public static ArceusSpecies Singleton { get => _singleton is null ? _singleton = new ArceusSpecies() : _singleton; }
		#endregion

		#region Constructor
		public ArceusSpecies() : base(
			493, "Arceus",
			new List<PokeType>(){
				TypeNormal.Singleton,
			},
			new Dictionary<string, int>(){
				{ "hp", 120 },
				{ "atk", 120 },
				{ "def", 120 },
				{ "spAtk", 120 },
				{ "spDef", 120 },
				{ "spd", 120 },
			},

			4, "Alpha Pokémon", PokeClass.Mythical,
			32, 3200
		)
		{ }
		#endregion
	}
}

namespace Pokedex.Models.Pokemons
{
	public class Arceus : Pokemon
	{
		#region Constructor
		public Arceus(int level)
			: base(ArceusSpecies.Singleton, level) { }
		public Arceus(int level, string nickname)
			: base(ArceusSpecies.Singleton, level, nickname) { }
		public Arceus(int level, string nickname, Nature nature)
			: base(ArceusSpecies.Singleton, level, nickname, nature) { }
		public Arceus(int level, string nickname, Nature nature, Dictionary<string, int> evs)
			: base(ArceusSpecies.Singleton, level, nickname, nature, evs) { }
		#endregion
	}
}