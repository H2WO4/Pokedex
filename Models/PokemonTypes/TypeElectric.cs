namespace Pokedex.Models.PokemonTypes
{
	public class TypeElectric : PokeType
	{
		#region Class Variables
		protected static TypeElectric? _singleton;
		#endregion

		#region Properties
		public static TypeElectric Singleton { get => _singleton ?? (_singleton = new TypeElectric()); }
		#endregion

		#region Constructor
		public TypeElectric() : base(
			"Electric", (245, 204, 52)
		)
		{ }
		#endregion
	}
}