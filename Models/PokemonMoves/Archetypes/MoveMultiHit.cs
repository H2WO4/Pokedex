using Pokedex.Enums;

namespace Pokedex.Models.PokemonMoves.Archetypes;

public abstract class MoveMultiHit : PokeMove
{
    protected MoveMultiHit
    (
        string name,
        MoveClass @class,
        int? power,
        int? accuracy,
        int maxPp,
        int priority,
        PokeType type
    )
        : base(name, @class, power, accuracy,
               maxPp, priority, type) { }

    public override void OnUse()
    {
        // Select targets
        var targets = GetTargets();

        // If it hits, deal damage, and check if fainted
        foreach (var target in targets)
        {
            // Get a random hit count between 2-5
            var hitCount  = Program.Rnd.Next(2, 6);
            var totalHits = 0;

            for (var i = 0; i < hitCount; i++)
            {
                var hit = AccuracyCheck(target);

                if (hit)
                {
                    DoAction(target);
                    totalHits++;
                }
                else
                    Console.WriteLine($"{Caster}'s {Name} missed {target}\n");
            }

            var finalS = totalHits > 1
                             ? "s"
                             : "";
            Console.WriteLine($"Hit {totalHits} time{finalS}");
        }
    }
}