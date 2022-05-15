using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.StatusEffects;

public class ParalysisEffect : StatusEffect
{
    #region Constructor
    public ParalysisEffect()
        : this(null) { }

    private ParalysisEffect(I_Battler? origin)
        : base("Paralysis", origin) { }
    #endregion

    #region Methods
    public override bool BeforeAttack(I_Skill move)
    {
        if (Program.Rnd.Next(0, 100) >= 50)
            return false;
        
        Console.WriteLine($"{Origin} is paralyzed and could not move!");
        return true;

    }

    public override int ChangeSpd(int spd)
        => spd / 2;
    
    public override bool Apply(I_Battler target)
    {
        if (target.Types.Contains(TypeElectric.Singleton))
            return false;

        var  effect = new ParalysisEffect(target);
        bool cancel = target.Ability.OnReceiveStatusEffect(effect);

        if (cancel)
            return false;
        
        target.StatusEffects.Add(effect);

        return true;
    }
    #endregion
}