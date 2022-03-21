namespace Pokedex.Models.PokemonTypes
{
	public class TypeSteel : PokeType
	{
		#region Class Variables
		protected static TypeSteel? __singleton;
		#endregion

		#region Properties
		public static TypeSteel Singleton { get => __singleton ?? (__singleton = new TypeSteel()); }
		#endregion

		#region Constructor
		public TypeSteel() : base(
			"Steel", (170, 170, 187)
		)
		{ }
		#endregion
	}
}