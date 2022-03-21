using Pokedex.Models.PokemonTypes;
using Pokedex.Enums;

namespace Pokedex.Models.Pokemons
{
	public class Arceus : PokeSpecies
	{
		#region Class Variables
		private static Arceus? __singleton;
		#endregion

		#region Properties
		public static Arceus Singleton { get => __singleton ?? (__singleton = new Arceus()); }
		#endregion

		#region Constructor
		public Arceus() : base
		(
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