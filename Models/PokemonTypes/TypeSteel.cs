namespace Pokedex.Models.PokemonTypes
{
	public class TypeSteel : PokeType
	{
		#region Class Variables
		protected static TypeSteel? _singleton;
		#endregion

		#region Properties
		public static TypeSteel Singleton { get => _singleton ?? (_singleton = new TypeSteel()); }
		#endregion

		#region Constructor
		public TypeSteel() : base(
			"Steel", (170, 170, 187)
		)
		{ }
		#endregion
	}
}