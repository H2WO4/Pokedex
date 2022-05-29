namespace Pokedex.Models.PokeTypes;

public class TypeWater : PokeType
{
    #region Class Variables
    private static TypeWater? _singleton;
    #endregion

    #region Properties
    public static TypeWater Singleton
        => _singleton ??= new TypeWater();
    #endregion

    #region Constructor
    private TypeWater()
        : base("Water") { }
    #endregion
}