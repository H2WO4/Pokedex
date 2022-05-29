using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface IM_StatusEffectRecoil<TEffect> : I_Skill
    where TEffect : StatusEffect, new()
{
    void I_Skill.DoBonusEffects(double applied, I_Battler target)
    {
        var effect = new TEffect();

        effect.Apply(Caster);
    }
}