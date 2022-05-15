using Pokedex.Enums;
using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface IM_Heal : I_Skill
{
    CalcClass CalcClass { get; }
    
    int HealingPower { get; }

    object I_Skill.CreateInfo()
    {
        return new HealingInfo(CalcClass, HealingPower);
    }
}