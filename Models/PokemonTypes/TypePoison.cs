namespace Pokedex.Models.PokemonTypes
{
	public class TypePoison : PokeType
	{
		#region Class Variables
		private static TypePoison? _singleton;
		#endregion

		#region Properties
		public static TypePoison Singleton => _singleton ??= new();
		#endregion

		#region Constructor
		private TypePoison() : base(
			"Poison", (170, 85, 153)
		)
		{ }
		#endregion
	}
}