namespace Pokedex.Models.PokemonTypes;

public class TypeIce : PokeType
{
	#region Class Variables
	private static TypeIce? _singleton;
	#endregion

	#region Constructor
	private TypeIce()
		: base("Ice", (102, 204, 255)) { }
	#endregion

	#region Properties
	public static TypeIce Singleton => _singleton ??= new TypeIce();
	#endregion
}