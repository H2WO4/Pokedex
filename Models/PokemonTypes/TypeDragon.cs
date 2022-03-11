namespace Pokedex.Models.PokemonTypes
{
	public class TypeDragon : PokeType
	{
		#region Class Variables
		protected static TypeDragon? _singleton;
		#endregion

		#region Properties
		public static TypeDragon Singleton { get => _singleton ?? (_singleton = new TypeDragon()); }
		#endregion

		#region Constructor
		public TypeDragon() : base(
			"Dragon", (120, 103, 238)
		)
		{ }
		#endregion
	}
}