namespace Pokedex.Models.PokemonTypes
{
	public class TypeFairy : PokeType
	{
		#region Class Variables
		private static TypeFairy? _singleton;
		#endregion

		#region Properties
		public static TypeFairy Singleton => _singleton ??= new();

		#endregion

		#region Constructor
		private TypeFairy() : base(
			"Fairy", (238, 153, 238)
		)
		{ }
		#endregion
	}
}