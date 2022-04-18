using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.StatusEffects;

public class BurnEffect : StatusEffect
{
    #region Constructor
    public BurnEffect(I_Battler origin)
        : base("Poison", origin) { }
    #endregion

    #region Methods
    public override void OnTurnEnd()
    {
        DamageHandler.DoDamageNoCaster(new DamageInfo(DamageClass.Percent, 6.25), Origin);
    }

    public override int ChangeAtk(int atk)
        => atk / 2;
    #endregion
}