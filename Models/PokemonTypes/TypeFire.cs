namespace Pokedex.Models.PokemonTypes
{
	public class TypeFire : PokeType
	{
		#region Class Variables
		protected static TypeFire? _singleton;
		#endregion

		#region Properties
		public static TypeFire Singleton { get => _singleton ?? (_singleton = new TypeFire()); }
		#endregion

		#region Constructor
		public TypeFire() : base(
			"Fire", (236, 66, 37)
		)
		{ }
		#endregion
	}
}