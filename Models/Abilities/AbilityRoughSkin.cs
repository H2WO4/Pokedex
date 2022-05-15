using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities;

public class AbilityRoughSkin : Ability
{
    #region Constructors
    public AbilityRoughSkin(Pokemon origin)
        : base("Rough Skin", origin) { }
    #endregion

    #region Methods
    public override void AfterReceiveDamage(DamageInfo dmgInfo, I_Battler? caster = null)
    {
        if (caster is null)
            return;
        
        if (!dmgInfo.Contact)
            return;

        Announce();
        InteractionHandler.DoDamage(new DamageInfo(CalcClass.Percent, 6.25), Origin, caster);
    }
    #endregion
}