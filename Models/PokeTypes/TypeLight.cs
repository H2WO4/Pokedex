namespace Pokedex.Models.PokeTypes;

public class TypeLight : PokeType
{
    #region Class Variables
    private static TypeLight? _singleton;
    #endregion

    #region Properties
    public static TypeLight Singleton
        => _singleton ??= new TypeLight();
    #endregion

    #region Constructor
    private TypeLight()
        : base("Light", (185, 188, 231)) { }
    #endregion
}