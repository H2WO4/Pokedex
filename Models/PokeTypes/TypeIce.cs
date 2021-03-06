namespace Pokedex.Models.PokeTypes;

public class TypeIce : PokeType
{
    #region Class Variables
    private static TypeIce? _singleton;
    #endregion

    #region Properties
    public static TypeIce Singleton
        => _singleton ??= new TypeIce();
    #endregion

    #region Constructor
    private TypeIce()
        : base("Ice") { }
    #endregion
}