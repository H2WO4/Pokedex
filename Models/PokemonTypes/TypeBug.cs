namespace Pokedex.Models.PokemonTypes
{
	public class TypeBug : PokeType
	{
		#region Class Variables
		protected static TypeBug? __singleton;
		#endregion

		#region Properties
		public static TypeBug Singleton { get => __singleton ?? (__singleton = new TypeBug()); }
		#endregion

		#region Constructor
		public TypeBug() : base(
			"Bug", (170, 187, 34)
		)
		{ }
		#endregion
	}
}