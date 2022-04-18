using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities;

public class AbilityColorChange : Models.Ability
{
    #region Variables
    private PokeType? _tempType;
    #endregion

    #region Constructors
    public AbilityColorChange(Pokemon origin)
        : base("Color Change", origin) { }
    #endregion

    #region Methods
    public override bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler? caster = null)
    {
        if (dmgInfo.Type is null)
            return true;

        Announce();
        _tempType = dmgInfo.Type;

        return true;
    }

    public override IEnumerable<PokeType>? ChangeType()
        => _tempType is null
               ? null
               : new[] { _tempType };
    #endregion
}