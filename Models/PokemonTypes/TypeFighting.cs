namespace Pokedex.Models.PokemonTypes
{
	public class TypeFighting : PokeType
	{
		#region Class Variables
		protected static TypeFighting? __singleton;
		#endregion

		#region Properties
		public static TypeFighting Singleton { get => __singleton ?? (__singleton = new TypeFighting()); }
		#endregion

		#region Constructor
		public TypeFighting() : base(
			"Fighting", (187, 85, 69)
		)
		{ }
		#endregion
	}
}