namespace Pokedex.Models.PokemonTypes
{
	public class TypePoison : PokeType
	{
		#region Class Variables
		protected static TypePoison? _singleton;
		#endregion

		#region Properties
		public static TypePoison Singleton { get => _singleton ?? (_singleton = new TypePoison()); }
		#endregion

		#region Constructor
		public TypePoison() : base(
			"Poison", (170, 85, 153)
		)
		{ }
		#endregion
	}
}