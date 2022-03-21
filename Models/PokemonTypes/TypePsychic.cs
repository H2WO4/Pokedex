namespace Pokedex.Models.PokemonTypes
{
	public class TypePsychic : PokeType
	{
		#region Class Variables
		protected static TypePsychic? __singleton;
		#endregion

		#region Properties
		public static TypePsychic Singleton { get => __singleton ?? (__singleton = new TypePsychic()); }
		#endregion

		#region Constructor
		public TypePsychic() : base(
			"Psychic", (238, 84, 153)
		)
		{ }
		#endregion
	}
}