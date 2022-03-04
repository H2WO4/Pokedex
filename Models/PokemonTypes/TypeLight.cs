namespace Pokedex.Models.PokemonTypes
{
	public class TypeLight : PokemonType
	{
		#region Class Variables
		protected static TypeLight? _singleton;
		#endregion

		#region Properties
		public static TypeLight Singleton { get => _singleton ?? (_singleton = new TypeLight()); }
		#endregion

		#region Constructor
		public TypeLight() : base(
			"Light", (200, 200, 200)
		)
		{ }
		#endregion
	}
}