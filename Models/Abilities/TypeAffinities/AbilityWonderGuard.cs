using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities;

public class AbilityWonderGuard : Ability
{
    #region Constructors
    public AbilityWonderGuard(Pokemon origin)
        : base("Wonder Guard", origin) { }
    #endregion

    #region Methods
    public override bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler? caster = null)
    {
        if (dmgInfo.Type?.CalculateAffinity(Origin.Types) > 1)
            return false;
        
        Announce();
        return true;

    }
    #endregion
}