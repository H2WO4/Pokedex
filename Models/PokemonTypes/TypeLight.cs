namespace Pokedex.Models.PokemonTypes
{
	public class TypeLight : PokeType
	{
		#region Class Variables
		protected static TypeLight? __singleton;
		#endregion

		#region Properties
		public static TypeLight Singleton { get => __singleton ?? (__singleton = new TypeLight()); }
		#endregion

		#region Constructor
		public TypeLight() : base(
			"Light", (185, 188, 231)
		)
		{ }
		#endregion
	}
}