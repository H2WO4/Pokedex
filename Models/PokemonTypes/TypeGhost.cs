namespace Pokedex.Models.PokemonTypes
{
	public class TypeGhost : PokeType
	{
		#region Class Variables
		protected static TypeGhost? __singleton;
		#endregion

		#region Properties
		public static TypeGhost Singleton { get => __singleton ?? (__singleton = new TypeGhost()); }
		#endregion

		#region Constructor
		public TypeGhost() : base(
			"Ghost", (102, 103, 188)
		)
		{ }
		#endregion
	}
}