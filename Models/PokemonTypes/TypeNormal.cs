namespace Pokedex.Models.PokemonTypes;

public class TypeNormal : PokeType
{
    #region Class Variables
    private static TypeNormal? _singleton;
    #endregion

    #region Properties
    public static TypeNormal Singleton
        => _singleton ??= new TypeNormal();
    #endregion

    #region Constructor
    public TypeNormal()
        : base("Normal", (170, 170, 153)) { }
    #endregion
}