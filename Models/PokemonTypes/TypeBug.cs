namespace Pokedex.Models.PokemonTypes
{
	public class TypeBug : PokeType
	{
		#region Class Variables
		protected static TypeBug? _singleton;
		#endregion

		#region Properties
		public static TypeBug Singleton { get => _singleton ?? (_singleton = new TypeBug()); }
		#endregion

		#region Constructor
		public TypeBug() : base(
			"Bug", (170, 187, 34)
		)
		{ }
		#endregion
	}
}