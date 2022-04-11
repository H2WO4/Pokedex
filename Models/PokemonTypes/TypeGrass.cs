namespace Pokedex.Models.PokemonTypes
{
	public class TypeGrass : PokeType
	{
		#region Class Variables
		private static TypeGrass? _singleton;
		#endregion

		#region Properties
		public static TypeGrass Singleton => _singleton ??= new();
		#endregion

		#region Constructor
		private TypeGrass() : base(
			"Grass", (119, 204, 85)
		)
		{ }
		#endregion
	}
}