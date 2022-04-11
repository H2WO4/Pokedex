namespace Pokedex.Models.PokemonTypes
{
	public class TypeSteel : PokeType
	{
		#region Class Variables
		private static TypeSteel? _singleton;
		#endregion

		#region Properties
		public static TypeSteel Singleton => _singleton ??= new();
		#endregion

		#region Constructor
		private TypeSteel() : base(
			"Steel", (170, 170, 187)
		)
		{ }
		#endregion
	}
}