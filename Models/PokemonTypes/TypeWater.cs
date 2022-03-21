namespace Pokedex.Models.PokemonTypes
{
	public class TypeWater : PokeType
	{
		#region Class Variables
		protected static TypeWater? __singleton;
		#endregion

		#region Properties
		public static TypeWater Singleton { get => __singleton ?? (__singleton = new TypeWater()); }
		#endregion

		#region Constructor
		public TypeWater() : base(
			"Water", (78, 154, 255)
		)
		{ }
		#endregion
	}
}