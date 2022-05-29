using Pokedex.Models;


namespace Pokedex.Interfaces.Archetypes;

public interface IM_Drain : I_Skill
{
    int DrainPower { get; }

    object I_Skill.CreateInfo(I_Battler target)
    {
        if (I_Skill.CreateInfo(this) is not DamageInfo dmgInfo)
            throw new InvalidOperationException();

        dmgInfo.DrainPower = DrainPower;

        return dmgInfo;
    }
}