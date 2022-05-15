using Pokedex.Models.Events;

namespace Pokedex.Interfaces.Archetypes;

public interface IM_SwitchAfter : I_Skill
{
    void I_Skill.DoBonusEffects(I_Battler target)
    {
        Arena.AddToTop(new SwitchInputEvent(Caster.Owner, Arena));
    }
}