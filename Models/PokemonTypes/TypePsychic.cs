namespace Pokedex.Models.PokemonTypes;

public class TypePsychic : PokeType
{
	#region Class Variables
	private static TypePsychic? _singleton;
	#endregion

	#region Constructor
	private TypePsychic()
		: base("Psychic", (238, 84, 153)) { }
	#endregion

	#region Properties
	public static TypePsychic Singleton => _singleton ??= new TypePsychic();
	#endregion
}