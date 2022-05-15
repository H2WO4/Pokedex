using Pokedex.Models.Abilities;

namespace Pokedex.Interfaces.Archetypes;

public interface IM_MultiHit : I_Skill
{
    void I_Skill.DoTarget(I_Battler target)
    {
        // Get a random hit count between 2-5
        int hitCount  = GenerateHitNumber();
        var totalHits = 0;

        for (var i = 0; i < hitCount; i++)
        {
            bool hit = AccuracyCheck(target);

            if (hit)
            {
                // Active the target's ability
                bool cancel = target.Ability.BeforeDefend(this);
                cancel = target.StatusEffects
                               .Aggregate(cancel, (current, effect) => current || effect.BeforeDefend(this));

                // Cancel the attack if needed
                if (cancel)
                    return;

                DoAction(target);
                totalHits++;

                target.Ability.AfterDefend(this);
            }
            else
                Console.WriteLine($"{Caster}'s {Name} missed {target}\n");
        }

        string finalS = totalHits == 1
                            ? ""
                            : "s";
        Console.WriteLine($"Hit {totalHits} time{finalS}");
    }

    private int GenerateHitNumber()
    {
        if (Caster.Ability is AbilitySkillLink)
            return 5;

        return Program.Rnd.Next(0, 100) switch
               {
                   < 35 => 2,
                   < 70 => 3,
                   < 85 => 4,
                   _    => 5,
               };
    }
}