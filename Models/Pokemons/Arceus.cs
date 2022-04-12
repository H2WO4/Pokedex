using Pokedex.Models.PokemonTypes;
using Pokedex.Enums;

namespace Pokedex.Models.Pokemons
{
	public class Arceus : PokeSpecies
	{
		#region Class Variables
		private static Arceus? _singleton;
		#endregion

		#region Properties
		public static Arceus Singleton => _singleton ??= new Arceus();
		#endregion

		#region Constructor
		public Arceus() : base
		(
			493, "Arceus",
			new List<PokeType>(){
				TypeNormal.Singleton,
			},
			new Dictionary<Stat, int>(){
				{ Stat.HP, 120 },
				{ Stat.Atk, 120 },
				{ Stat.Def, 120 },
				{ Stat.SpAtk, 120 },
				{ Stat.SpDef, 120 },
				{ Stat.Spd, 120 },
			},

			4, "Alpha Pokémon", PokeClass.Mythical,
			32, 3200
		)
		{ }
		#endregion
	}
}