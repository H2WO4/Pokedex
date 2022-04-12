namespace Pokedex.Models.PokemonTypes;

public class TypeDragon : PokeType
{
	#region Class Variables
	private static TypeDragon? _singleton;
	#endregion

	#region Properties
	public static TypeDragon Singleton => _singleton ??= new TypeDragon();

	#endregion

	#region Constructor
	private TypeDragon() : base(
		"Dragon", (120, 103, 238)
	)
	{ }
	#endregion
}