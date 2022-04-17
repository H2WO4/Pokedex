using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities;

public class AbilityProtean : Models.Ability
{
    #region Variables
    private PokeType? _tempType;
    #endregion

    #region Constructors
    public AbilityProtean(Pokemon origin)
        : base("Protean", origin) { }
    #endregion

    #region Methods
    public override bool BeforeAttack(I_PokeMove move)
    {
        Announce();
        _tempType = move.Type;

        return false;
    }

    public override List<PokeType>? ChangeType()
        => _tempType != null
               ? new List<PokeType> { _tempType }
               : null;
    #endregion
}