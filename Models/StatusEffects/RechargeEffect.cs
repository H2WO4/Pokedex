using Pokedex.Interfaces;

namespace Pokedex.Models.StatusEffects;

public class RechargeEffect : StatusEffect
{
    #region Constructor
    public RechargeEffect()
        : this(null) { }

    private RechargeEffect(I_Battler? origin)
        : base("Recharge", origin) { }
    #endregion

    #region Methods
    public override void OnTurnStart()
    {
        Console.WriteLine($"{Origin} needs to recharge!");
    }

    public override bool SkipTurn()
        => true;

    public override void OnTurnEnd()
    {
        Origin.StatusEffects.Remove(this);
    }

    public override bool Apply(I_Battler target)
    {
        target.StatusEffects.Add(new RechargeEffect(target) { Timer = 0 });

        return true;
    }
    #endregion
}