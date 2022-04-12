namespace Pokedex.Models.PokemonTypes;

public class TypeElectric : PokeType
{
	#region Class Variables
	private static TypeElectric? _singleton;
	#endregion

	#region Properties
	public static TypeElectric Singleton => _singleton ??= new TypeElectric();

	#endregion

	#region Constructor
	private TypeElectric() : base(
		"Electric", (245, 204, 52)
	)
	{ }
	#endregion
}