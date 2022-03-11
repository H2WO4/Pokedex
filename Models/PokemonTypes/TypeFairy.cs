namespace Pokedex.Models.PokemonTypes
{
	public class TypeFairy : PokeType
	{
		#region Class Variables
		protected static TypeFairy? _singleton;
		#endregion

		#region Properties
		public static TypeFairy Singleton { get => _singleton ?? (_singleton = new TypeFairy()); }
		#endregion

		#region Constructor
		public TypeFairy() : base(
			"Fairy", (238, 153, 238)
		)
		{ }
		#endregion
	}
}