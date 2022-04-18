using Pokedex.Interfaces;

namespace Pokedex.Models.StatusEffects;

public class ParalysisEffect : StatusEffect
{
    #region Constructor
    public ParalysisEffect(I_Battler origin)
        : base("Poison", origin) { }
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
    #endregion
}