namespace Pokedex.Models.PokemonTypes
{
	public class TypeWater : PokeType
	{
		#region Class Variables
		protected static TypeWater? _singleton;
		#endregion

		#region Properties
		public static TypeWater Singleton { get => _singleton ?? (_singleton = new TypeWater()); }
		#endregion

		#region Constructor
		public TypeWater() : base(
			"Water", (78, 154, 255)
		)
		{ }
		#endregion
	}
}