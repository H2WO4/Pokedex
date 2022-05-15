using Pokedex.Enums;
using Pokedex.Models;


namespace Pokedex.Interfaces.Archetypes;

public interface IM_StatChange : I_Skill
{
    Stat StatToChange { get; }

    int ChangeValue { get; }

    void I_Skill.DoAction(I_Battler target)
    {
        if (target is Pokemon poke)
            poke.ChangeStatBonus(StatToChange, ChangeValue);
    }
}