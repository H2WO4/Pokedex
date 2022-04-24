namespace Pokedex.Models.PokeTypes;

public class TypeBug : PokeType
{
    #region Class Variables
    private static TypeBug? _singleton;
    #endregion

    #region Properties
    public static TypeBug Singleton
        => _singleton ??= new TypeBug();
    #endregion

    #region Constructor
    private TypeBug()
        : base("Bug", (170, 187, 34)) { }
    #endregion
}