namespace Pokedex.Models.PokeTypes;

public class TypeGhost : PokeType
{
    #region Class Variables
    private static TypeGhost? _singleton;
    #endregion

    #region Properties
    public static TypeGhost Singleton
        => _singleton ??= new TypeGhost();
    #endregion

    #region Constructor
    private TypeGhost()
        : base("Ghost") { }
    #endregion
}