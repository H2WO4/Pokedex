namespace Pokedex.Models.PokemonTypes;

public class TypeWater : PokeType
{
	#region Class Variables
	private static TypeWater? _singleton;
	#endregion

	#region Properties
	public static TypeWater Singleton => _singleton ??= new TypeWater();
	#endregion

	#region Constructor
	private TypeWater() : base(
		"Water", (78, 154, 255)
	)
	{ }
	#endregion
}