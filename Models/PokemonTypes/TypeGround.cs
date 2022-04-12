namespace Pokedex.Models.PokemonTypes;

public class TypeGround : PokeType
{
	#region Class Variables
	private static TypeGround? _singleton;
	#endregion

	#region Properties
	public static TypeGround Singleton => _singleton ??= new TypeGround();
	#endregion

	#region Constructor
	private TypeGround() : base(
		"Ground", (221, 187, 85)
	)
	{ }
	#endregion
}