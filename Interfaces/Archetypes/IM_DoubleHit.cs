namespace Pokedex.Interfaces.Archetypes;

public interface I_DoubleHit : I_Skill
{
    void I_Skill.OnUse()
    {
        // Active the caster's ability
        bool cancel = Caster.Ability.BeforeAttack(this);
        cancel = Caster.StatusEffects
                       .Aggregate(cancel, (current, effect) => current || effect.BeforeAttack(this));

        // Cancel the attack if needed
        if (cancel)
            return;

        // For each target, if the move hits, deal damage
        foreach (I_Battler target in GetTargets())
        {
            var totalHits = 0;

            for (var i = 0; i < 2; i++)
            {
                bool hit = AccuracyCheck(target);

                if (hit)
                {
                    // Active the target's ability
                    cancel = target.Ability.BeforeDefend(this);
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

        Caster.Ability.AfterAttack(this);
    }
}