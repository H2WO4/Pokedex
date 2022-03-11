namespace Pokedex.Models.PokemonTypes
{
	public class TypeFighting : PokeType
	{
		#region Class Variables
		protected static TypeFighting? _singleton;
		#endregion

		#region Properties
		public static TypeFighting Singleton { get => _singleton ?? (_singleton = new TypeFighting()); }
		#endregion

		#region Constructor
		public TypeFighting() : base(
			"Fighting", (187, 85, 69)
		)
		{ }
		#endregion
	}
}