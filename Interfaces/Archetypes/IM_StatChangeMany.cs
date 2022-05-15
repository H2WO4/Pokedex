using Pokedex.Enums;
using Pokedex.Models;


namespace Pokedex.Interfaces.Archetypes;

public interface IM_StatChangeMany : I_Skill
{
    IEnumerable<Stat> StatsToChange { get; }

    IEnumerable<int> ChangeValues { get; }

    void I_Skill.DoAction(I_Battler target)
    {
        if (target is not Pokemon poke)
            return;
        
        foreach ((Stat stat, int val) in StatsToChange.Zip(ChangeValues))
            poke.ChangeStatBonus(stat, val);
    }
}