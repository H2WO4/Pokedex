using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface I_StatusEffect<TEffect> : I_Skill
    where TEffect : StatusEffect, new()
{
    void I_Skill.DoAction(I_Battler target)
    {
        var effect = new TEffect();

        effect.Apply(target);
    }
}