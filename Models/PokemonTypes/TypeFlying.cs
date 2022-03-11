namespace Pokedex.Models.PokemonTypes
{
	public class TypeFlying : PokeType
	{
		#region Class Variables
		protected static TypeFlying? _singleton;
		#endregion

		#region Properties
		public static TypeFlying Singleton { get => _singleton ?? (_singleton = new TypeFlying()); }
		#endregion

		#region Constructor
		public TypeFlying() : base(
			"Flying", (136, 153, 255)
		)
		{ }
		#endregion
	}
}