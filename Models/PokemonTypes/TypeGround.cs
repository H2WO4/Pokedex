namespace Pokedex.Models.PokemonTypes
{
	public class TypeGround : PokeType
	{
		#region Class Variables
		protected static TypeGround? __singleton;
		#endregion

		#region Properties
		public static TypeGround Singleton { get => __singleton ?? (__singleton = new TypeGround()); }
		#endregion

		#region Constructor
		public TypeGround() : base(
			"Ground", (221, 187, 85)
		)
		{ }
		#endregion
	}
}