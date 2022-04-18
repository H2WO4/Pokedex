using Pokedex.Interfaces;

namespace Pokedex.Models.StatusEffects;

public class FreezeEffect : StatusEffect
{
    #region Constructor
    public FreezeEffect(I_Battler origin)
        : base("Poison", origin) { }
    #endregion

    #region Methods
    public override bool BeforeAttack(I_Skill move)
    {
        if (Program.Rnd.Next(0, 100) >= 80)
            return true;
        
        Timer = 0;
        return false;
    }

    public override int ChangeSpd(int spd)
        => spd / 2;
    #endregion
}