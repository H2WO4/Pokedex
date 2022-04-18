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
    public override bool BeforeAttack(I_Skill move)
    {
        Announce();
        _tempType = move.Type;

        return false;
    }

    public override IEnumerable<PokeType>? ChangeType()
        => _tempType is null
               ? null
               : new[] { _tempType };
    #endregion
}