namespace Pokedex.Models.PokemonTypes
{
	public class TypeRock : PokeType
	{
		#region Class Variables
		protected static TypeRock? _singleton;
		#endregion

		#region Properties
		public static TypeRock Singleton { get => _singleton ?? (_singleton = new TypeRock()); }
		#endregion

		#region Constructor
		public TypeRock() : base(
			"Rock", (187, 170, 102)
		)
		{ }
		#endregion
	}
}