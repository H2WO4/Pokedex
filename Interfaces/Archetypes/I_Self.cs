namespace Pokedex.Interfaces.Archetypes;

public interface I_Self : I_Skill
{
    public new IEnumerable<I_Battler> GetTargets()
    {
        yield return Caster;
    }
}