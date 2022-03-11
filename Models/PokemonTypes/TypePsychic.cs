namespace Pokedex.Models.PokemonTypes
{
	public class TypePsychic : PokeType
	{
		#region Class Variables
		protected static TypePsychic? _singleton;
		#endregion

		#region Properties
		public static TypePsychic Singleton { get => _singleton ?? (_singleton = new TypePsychic()); }
		#endregion

		#region Constructor
		public TypePsychic() : base(
			"Psychic", (238, 84, 153)
		)
		{ }
		#endregion
	}
}