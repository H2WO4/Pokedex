namespace Pokedex.Models.PokemonTypes
{
	public class TypeIce : PokeType
	{
		#region Class Variables
		protected static TypeIce? __singleton;
		#endregion

		#region Properties
		public static TypeIce Singleton { get => __singleton ?? (__singleton = new TypeIce()); }
		#endregion

		#region Constructor
		public TypeIce() : base(
			"Ice", (102, 204, 255)
		)
		{ }
		#endregion
	}
}