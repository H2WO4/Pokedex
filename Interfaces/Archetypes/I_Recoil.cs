using Pokedex.Enums;
using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface I_Recoil : I_Skill
{
    int RecoilPower { get; }
    
    public new void DoBonusEffects(I_Battler target)
    {
        DamageHandler.DoDamageNoCaster(new DamageInfo(DamageClass.Percent, RecoilPower), Caster);
    }
}