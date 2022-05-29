using Pokedex.Enums;
using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface IM_RecoilPercent : I_Skill
{
    int RecoilPower { get; }
    
    void I_Skill.DoBonusEffects(double applied, I_Battler target)
    {
        double recoil = applied * RecoilPower / 100;
        InteractionHandler.DoDamageNoCaster(new DamageInfo(CalcClass.Pure, recoil), Caster);
    }
}