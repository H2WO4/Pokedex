using Pokedex.Models.Abilities;

namespace Pokedex.Interfaces.Archetypes;

public interface IM_MultiHit : I_Skill
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
            // Get a random hit count between 2-5
            int hitCount  = GenerateHitNumber();
            var totalHits = 0;

            for (var i = 0; i < hitCount; i++)
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