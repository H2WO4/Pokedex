namespace Pokedex.Models.PokeTypes;

public class TypeRock : PokeType
{
    #region Class Variables
    private static TypeRock? _singleton;
    #endregion

    #region Properties
    public static TypeRock Singleton
        => _singleton ??= new TypeRock();
    #endregion

    #region Constructor
    private TypeRock()
        : base("Rock") { }
    #endregion
}