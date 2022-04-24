namespace Pokedex.Interfaces.Archetypes;

public interface I_OHKO : I_Skill
{
    public new void DoAction(I_Battler target)
        => target.DoKO();
}