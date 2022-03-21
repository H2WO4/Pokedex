namespace Pokedex.Models.PokemonTypes
{
	public class TypeGrass : PokeType
	{
		#region Class Variables
		protected static TypeGrass? __singleton;
		#endregion

		#region Properties
		public static TypeGrass Singleton { get => __singleton ?? (__singleton = new TypeGrass()); }
		#endregion

		#region Constructor
		public TypeGrass() : base(
			"Grass", (119, 204, 85)
		)
		{ }
		#endregion
	}
}