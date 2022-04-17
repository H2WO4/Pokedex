namespace Pokedex.Models.PokemonTypes;

public class TypeFlying : PokeType
{
	#region Class Variables
	private static TypeFlying? _singleton;
	#endregion

	#region Constructor
	private TypeFlying()
		: base("Flying", (136, 153, 255)) { }
	#endregion

	#region Properties
	public static TypeFlying Singleton => _singleton ??= new TypeFlying();
	#endregion
}