namespace Pokedex.Models.PokemonTypes
{
	public class TypeNormal : PokeType
	{
		#region Class Variables
		protected static TypeNormal? __singleton;
		#endregion

		#region Properties
		public static TypeNormal Singleton { get => __singleton ?? (__singleton = new TypeNormal()); }
		#endregion

		#region Constructor
		public TypeNormal() : base(
			"Normal", (170, 170, 153)
		)
		{ }
		#endregion
	}
}