namespace Pokedex.Models.PokemonTypes;

public class TypeFighting : PokeType
{
	#region Class Variables
	private static TypeFighting? _singleton;
	#endregion

	#region Constructor
	private TypeFighting()
		: base("Fighting", (187, 85, 69)) { }
	#endregion

	#region Properties
	public static TypeFighting Singleton => _singleton ??= new TypeFighting();
	#endregion
}