﻿using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.StatusEffects;

public class PoisonEffect : StatusEffect
{
    #region Constructor
    public PoisonEffect()
        : this(null) { }

    private PoisonEffect(I_Battler? origin)
        : base("Poison", origin) { }
    #endregion

    #region Methods
    public override void OnTurnEnd()
    {
        Console.WriteLine($"{Origin} is poisoned!");
        DamageHandler.DoDamageNoCaster(new DamageInfo(DamageClass.Percent, 12.5), Origin);
    }
    
    public override void Apply(I_Battler target)
    {
        if (target.Types.Contains(TypeSteel.Singleton))
            return;
        
        var  effect = new PoisonEffect(target);
        bool cancel = target.Ability.OnReceiveStatusEffect(effect);

        if (cancel)
            return;

        target.StatusEffects.Add(effect);
    }
    #endregion
}