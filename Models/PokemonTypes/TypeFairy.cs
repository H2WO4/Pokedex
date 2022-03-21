namespace Pokedex.Models.PokemonTypes
{
	public class TypeFairy : PokeType
	{
		#region Class Variables
		protected static TypeFairy? __singleton;
		#endregion

		#region Properties
		public static TypeFairy Singleton { get => __singleton ?? (__singleton = new TypeFairy()); }
		#endregion

		#region Constructor
		public TypeFairy() : base(
			"Fairy", (238, 153, 238)
		)
		{ }
		#endregion
	}
}