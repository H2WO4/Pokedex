namespace Pokedex.Models.PokeTypes;

public class TypeFairy : PokeType
{
    #region Class Variables
    private static TypeFairy? _singleton;
    #endregion

    #region Properties
    public static TypeFairy Singleton
        => _singleton ??= new TypeFairy();
    #endregion

    #region Constructor
    private TypeFairy()
        : base("Fairy") { }
    #endregion
}