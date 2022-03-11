namespace Pokedex.Models.PokemonTypes
{
	public class TypeLight : PokeType
	{
		#region Class Variables
		protected static TypeLight? _singleton;
		#endregion

		#region Properties
		public static TypeLight Singleton { get => _singleton ?? (_singleton = new TypeLight()); }
		#endregion

		#region Constructor
		public TypeLight() : base(
			"Light", (185, 188, 231)
		)
		{ }
		#endregion
	}
}