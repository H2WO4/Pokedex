using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface IM_StatusEffectBonus<TEffect> : I_Skill
    where TEffect : StatusEffect, new()
{
    int EffectChance { get; }

    void I_Skill.DoBonusEffects(I_Battler target)
    {
        var effect = new TEffect();

        if (Program.Rnd.Next(0, 100) < EffectChance)
            effect.Apply(target);
    }
}