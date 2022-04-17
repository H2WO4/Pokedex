namespace Pokedex.Models.PokemonTypes;

public class TypeGhost : PokeType
{
	#region Class Variables
	private static TypeGhost? _singleton;
	#endregion

	#region Constructor
	private TypeGhost()
		: base("Ghost", (102, 103, 188)) { }
	#endregion

	#region Properties
	public static TypeGhost Singleton => _singleton ??= new TypeGhost();
	#endregion
}