using Pokedex.Enums;
using Pokedex.Models;


namespace Pokedex.Interfaces.Archetypes;

public interface IM_StatChangeChance : I_Skill
{
    Stat StatToChange { get; }

    int ChangeValue { get; }

    int EffectChance { get; }

    void I_Skill.DoBonusEffects(I_Battler target)
    {
        if (target is Pokemon poke
         && Program.Rnd.Next(0, 100) < EffectChance)
            poke.ChangeStatBonus(StatToChange, ChangeValue);
    }
}