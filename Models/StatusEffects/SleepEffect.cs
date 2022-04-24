using Pokedex.Interfaces;

namespace Pokedex.Models.StatusEffects;

public class SleepEffect : StatusEffect
{
    #region Constructor
    public SleepEffect()
        : this(null) { }

    private SleepEffect(I_Battler? origin, int? turns = null)
        : base("Sleep", origin)
    {
        Timer = turns ?? Program.Rnd.Next(1, 4);
    }
    #endregion

    #region Methods
    public override bool BeforeAttack(I_Skill move)
    {
        if (Timer != 0)
        {
            Console.WriteLine($"{Origin} is asleep!");
            Timer--;

            return true;
        }

        Console.WriteLine($"{Origin} woke up!");
        Origin.StatusEffects.Remove(this);

        return false;
    }

    public override void Apply(I_Battler target)
        => Apply(target, null);
    
    public static void Apply(I_Battler target, int? turns)
    {
        var  effect = new SleepEffect(target, turns);
        bool cancel = target.Ability.OnReceiveStatusEffect(effect);

        if (cancel)
            return;

        target.StatusEffects.Add(effect);
    }
    #endregion
}