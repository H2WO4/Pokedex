namespace Pokedex.Models.PokeTypes;

public class TypeNormal : PokeType
{
    #region Class Variables
    private static TypeNormal? _singleton;
    #endregion

    #region Properties
    public static TypeNormal Singleton
        => _singleton ??= new TypeNormal();
    #endregion

    #region Constructor
    private TypeNormal()
        : base("Normal", (170, 170, 153)) { }
    #endregion
}