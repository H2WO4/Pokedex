using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface I_Effect<TEffect> : I_Skill
    where TEffect : StatusEffect, new()
{
    int EffectChance { get; }

    public new void DoBonusEffects(I_Battler target)
    {
        var effect = new TEffect();

        if (Program.Rnd.Next(0, 100) < EffectChance)
            effect.Apply(target);
    }
}