using Pokedex.Enums;
using Pokedex.Models;


namespace Pokedex.Interfaces.Archetypes;

public interface IM_SpecialDamage : I_Skill
{
    object I_Skill.CreateInfo(I_Battler target)
    {
        return new DamageInfo(CalcClass.Pure, CalculateDamage(target), Type);
    }

    double CalculateDamage(I_Battler target);
}