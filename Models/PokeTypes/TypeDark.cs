namespace Pokedex.Models.PokeTypes;

public class TypeDark : PokeType
{
    #region Class Variables
    private static TypeDark? _singleton;
    #endregion

    #region Properties
    public static TypeDark Singleton
        => _singleton ??= new TypeDark();
    #endregion

    #region Constructor
    private TypeDark()
        : base("Dark", (119, 85, 68)) { }
    #endregion
}