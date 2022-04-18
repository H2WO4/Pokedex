using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.StatusEffects;

public class PoisonEffect : StatusEffect
{
    #region Constructor
    public PoisonEffect(I_Battler origin)
        : base("Poison", origin) { }
    #endregion

    #region Methods
    public override void OnTurnEnd()
    {
        Console.WriteLine($"{Origin} is poisoned!");
        DamageHandler.DoDamageNoCaster(new DamageInfo(DamageClass.Percent, 12.5), Origin);
    }
    #endregion
}