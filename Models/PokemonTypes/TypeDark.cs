namespace Pokedex.Models.PokemonTypes;

public class TypeDark : PokeType
{
	#region Class Variables
	private static TypeDark? _singleton;
	#endregion

	#region Constructor
	private TypeDark()
		: base("Dark", (119, 85, 68)) { }
	#endregion

	#region Properties
	public static TypeDark Singleton => _singleton ??= new TypeDark();
	#endregion
}