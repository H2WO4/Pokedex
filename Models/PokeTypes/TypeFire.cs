namespace Pokedex.Models.PokeTypes;

public class TypeFire : PokeType
{
    #region Class Variables
    private static TypeFire? _singleton;
    #endregion

    #region Properties
    public static TypeFire Singleton
        => _singleton ??= new TypeFire();
    #endregion

    #region Constructor
    private TypeFire()
        : base("Fire", (236, 66, 37)) { }
    #endregion
}