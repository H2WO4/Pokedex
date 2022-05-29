namespace Pokedex.Models.PokeTypes;

public class TypeFighting : PokeType
{
    #region Class Variables
    private static TypeFighting? _singleton;
    #endregion

    #region Properties
    public static TypeFighting Singleton
        => _singleton ??= new TypeFighting();
    #endregion

    #region Constructor
    private TypeFighting()
        : base("Fighting") { }
    #endregion
}