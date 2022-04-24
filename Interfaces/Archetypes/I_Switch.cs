using Pokedex.Models.Events;

namespace Pokedex.Interfaces.Archetypes;

public interface I_Switch : I_Skill
{
    public new void DoBonusEffects(I_Battler target)
    {
        Arena.AddToTop(new SwitchInputEvent(Caster.Owner, Arena));
    }
}