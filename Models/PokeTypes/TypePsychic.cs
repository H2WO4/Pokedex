namespace Pokedex.Models.PokeTypes;

public class TypePsychic : PokeType
{
    #region Class Variables
    private static TypePsychic? _singleton;
    #endregion

    #region Properties
    public static TypePsychic Singleton
        => _singleton ??= new TypePsychic();
    #endregion

    #region Constructor
    private TypePsychic()
        : base("Psychic", (238, 84, 153)) { }
    #endregion
}