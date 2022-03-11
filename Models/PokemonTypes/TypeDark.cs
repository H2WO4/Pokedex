namespace Pokedex.Models.PokemonTypes
{
	public class TypeDark : PokeType
	{
		#region Class Variables
		protected static TypeDark? _singleton;
		#endregion

		#region Properties
		public static TypeDark Singleton { get => _singleton ?? (_singleton = new TypeDark()); }
		#endregion

		#region Constructor
		public TypeDark() : base(
			"Dark", (119, 85, 68)
		)
		{ }
		#endregion
	}
}