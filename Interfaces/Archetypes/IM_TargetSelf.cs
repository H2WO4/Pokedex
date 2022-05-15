namespace Pokedex.Interfaces.Archetypes;

public interface IM_TargetSelf : I_Skill
{
    IEnumerable<I_Battler> I_Skill.GetTargets()
    {
        yield return Caster;
    }
}