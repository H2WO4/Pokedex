namespace Pokedex.Models.PokemonTypes
{
	public class TypeGrass : PokeType
	{
		#region Class Variables
		protected static TypeGrass? _singleton;
		#endregion

		#region Properties
		public static TypeGrass Singleton { get => _singleton ?? (_singleton = new TypeGrass()); }
		#endregion

		#region Constructor
		public TypeGrass() : base(
			"Grass", (119, 204, 85)
		)
		{ }
		#endregion
	}
}