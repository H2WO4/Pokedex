using Pokedex.Enums;
using Pokedex.Models;


namespace Pokedex.Interfaces.Archetypes;

public interface IM_StatChangeBonus : I_Skill
{
    IEnumerable<Stat> StatsToChange { get; }

    IEnumerable<int> ChangeValues { get; }

    int EffectChance { get; }

    void I_Skill.DoBonusEffects(double applied, I_Battler target)
    {
        if (target is not Pokemon poke
         || Program.Rnd.Next(0, 100) >= EffectChance)
            return;

        foreach ((Stat stat, int val) in StatsToChange.Zip(ChangeValues))
            poke.ChangeStatBonus(stat, val);
    }
}