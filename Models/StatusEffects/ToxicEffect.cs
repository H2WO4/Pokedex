using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.StatusEffects;

public class ToxicEffect : StatusEffect
{
    #region Variables
    private int _turn = 1;
    #endregion

    #region Constructor
    public ToxicEffect(I_Battler origin)
        : base("Toxic Poison", origin) { }
    #endregion

    #region Methods
    public override void OnEnter()
        => _turn = 1;

    public override void OnTurnEnd()
    {
        DamageHandler.DoDamageNoCaster(new DamageInfo(DamageClass.Percent, 6.25 * _turn), Origin);
        _turn++;
    }
    
    public static void Apply(I_Battler target)
    {
        var  effect = new ToxicEffect(target);
        bool cancel = target.Ability.OnReceiveStatusEffect(effect);

        if (cancel)
            return;

        target.StatusEffects.Add(effect);
    }
    #endregion
}