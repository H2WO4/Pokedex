namespace Pokedex.Interfaces.Archetypes;

public interface IM_OHKO : I_Skill
{
    void I_Skill.DoAction(I_Battler target)
    {
        target.DoKO();
    }
}