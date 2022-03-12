using Pokedex.Enums;

namespace Pokedex.Models.PokemonMoves.Archetypes
{
	public abstract class MoveMultiHit : PokemonMove
	{
		public MoveMultiHit
		(
			string name,
			MoveClass class_,
			int? power,
			int? accuracy,
			int maxPp,
			int priority,
			PokeType type
		) : base(name, class_, power, accuracy, maxPp, priority, type) { }

		public override void OnUse()
		{
			// Select targets
			var targets = this.GetTargets();

			// If it hits, deal damage, and check if fainted
			foreach (var target in targets)
			{
				// Get a random hit count between 2-5
				int hitCount = Program.rnd.Next(2, 6);
				var totalHits = 0;

				for (var i = 0; i < hitCount; i++)
				{
					var hit = this.AccuracyCheck(target);

					if (hit)
					{
						this.DoAction(target);
						totalHits++;
					}
					else
						Console.WriteLine($"{this.Caster.Name}'s {this.Name} missed {target.Name}\n");
				}

				string finalS = totalHits > 1 ? "s" : "";
				Console.WriteLine($"Hit {totalHits} time{finalS}");
			}
		}
	}
}