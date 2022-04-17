using Pokedex.Enums;
using Pokedex.Interfaces;


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
		// Active the caster's ability
		bool cancel = Caster.Ability.BeforeAttack(this);

		// Cancel the attack if needed
		if (cancel)
			return;

		// For each target, if the move hits, deal damage
		foreach (I_Battler? target in GetTargets())
		{
			// Get a random hit count between 2-5
			int hitCount  = Program.Rnd.Next(2, 6);
			var totalHits = 0;

			for (var i = 0; i < hitCount; i++)
			{
				bool hit = AccuracyCheck(target);

				if (hit)
				{
					DoAction(target);
					totalHits++;
				}
				else
					Console.WriteLine($"{Caster.Name}'s {Name} missed {target.Name}\n");
			}

			string finalS = totalHits > 1 ? "s" : "";
			Console.WriteLine($"Hit {totalHits} time{finalS}");
		}
	}
}