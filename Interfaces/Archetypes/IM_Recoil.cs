using Pokedex.Enums;
using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface IM_Recoil : I_Skill
{
    int RecoilPower { get; }
    
    void I_Skill.DoBonusEffects(double applied, I_Battler target)
    {
        InteractionHandler.DoDamageNoCaster(new DamageInfo(CalcClass.Percent, RecoilPower), Caster);
    }
}