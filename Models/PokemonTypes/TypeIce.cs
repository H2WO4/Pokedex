namespace Pokedex.Models.PokemonTypes
{
	public class TypeIce : PokeType
	{
		#region Class Variables
		protected static TypeIce? _singleton;
		#endregion

		#region Properties
		public static TypeIce Singleton { get => _singleton ?? (_singleton = new TypeIce()); }
		#endregion

		#region Constructor
		public TypeIce() : base(
			"Ice", (102, 204, 255)
		)
		{ }
		#endregion
	}
}