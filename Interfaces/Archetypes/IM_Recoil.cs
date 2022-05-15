using Pokedex.Enums;
using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface I_Recoil : I_Skill
{
    int RecoilPower { get; }
    
    void I_Skill.DoBonusEffects(I_Battler target)
    {
        InteractionHandler.DoDamageNoCaster(new DamageInfo(CalcClass.Percent, RecoilPower), Caster);
    }
}