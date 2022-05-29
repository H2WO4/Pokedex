namespace Pokedex.Models.PokeTypes;

public class TypeGrass : PokeType
{
    #region Class Variables
    private static TypeGrass? _singleton;
    #endregion

    #region Properties
    public static TypeGrass Singleton
        => _singleton ??= new TypeGrass();
    #endregion

    #region Constructor
    private TypeGrass()
        : base("Grass") { }
    #endregion
}