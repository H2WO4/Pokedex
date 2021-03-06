namespace Pokedex.Models.PokeTypes;

public class TypeFlying : PokeType
{
    #region Class Variables
    private static TypeFlying? _singleton;
    #endregion

    #region Properties
    public static TypeFlying Singleton
        => _singleton ??= new TypeFlying();
    #endregion

    #region Constructor
    private TypeFlying()
        : base("Flying") { }
    #endregion
}