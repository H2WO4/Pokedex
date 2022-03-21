namespace Pokedex.Models.PokemonTypes
{
	public class TypeFlying : PokeType
	{
		#region Class Variables
		protected static TypeFlying? __singleton;
		#endregion

		#region Properties
		public static TypeFlying Singleton { get => __singleton ?? (__singleton = new TypeFlying()); }
		#endregion

		#region Constructor
		public TypeFlying() : base(
			"Flying", (136, 153, 255)
		)
		{ }
		#endregion
	}
}