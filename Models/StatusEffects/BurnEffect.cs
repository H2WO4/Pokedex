using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.StatusEffects;

public class BurnEffect : StatusEffect
{
    #region Constructor
    public BurnEffect()
        : this(null) { }

    private BurnEffect(I_Battler? origin)
        : base("Burn", origin) { }
    #endregion

    #region Methods
    public override void OnTurnEnd()
    {
        InteractionHandler.DoDamageNoCaster(new DamageInfo(CalcClass.Percent, 6.25), Origin);
    }

    public override int ChangeAtk(int atk)
        => atk / 2;

    public override bool Apply(I_Battler target)
    {
        if (target.Types.Contains(TypeFire.Singleton))
            return false;

        var  effect = new BurnEffect(target);
        bool cancel = target.Ability.OnReceiveStatusEffect(effect);

        if (cancel)
            return false;
        
        target.StatusEffects.Add(effect);

        return true;
    }
    #endregion
}