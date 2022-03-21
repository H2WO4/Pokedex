namespace Pokedex.Models.PokemonTypes
{
	public class TypeElectric : PokeType
	{
		#region Class Variables
		protected static TypeElectric? __singleton;
		#endregion

		#region Properties
		public static TypeElectric Singleton { get => __singleton ?? (__singleton = new TypeElectric()); }
		#endregion

		#region Constructor
		public TypeElectric() : base(
			"Electric", (245, 204, 52)
		)
		{ }
		#endregion
	}
}