using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;


namespace Pokedex.Models.StatusEffects;

public class BurnEffect : StatusEffect
{
    #region Constructor
    public BurnEffect(I_Battler origin)
        : base("Burn", origin) { }
    #endregion

    #region Methods
    public override void OnTurnEnd()
    {
        DamageHandler.DoDamageNoCaster(new DamageInfo(DamageClass.Percent, 6.25), Origin);
    }

    public override int ChangeAtk(int atk)
        => atk / 2;

    public static void Apply(I_Battler target)
    {
        if (target.Types.Contains(TypeFire.Singleton))
            return;

        var  effect = new BurnEffect(target);
        bool cancel = target.Ability.OnReceiveStatusEffect(effect);

        if (cancel)
            return;
        
        target.StatusEffects.Add(effect);
    }
    #endregion
}