namespace Pokedex.Interfaces.Archetypes;

public interface IM_DoubleHit : I_Skill
{
    void I_Skill.DoTarget(I_Battler target)
    {
        var totalHits = 0;

        for (var i = 0; i < 2; i++)
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

                // Active the target's ability
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
}