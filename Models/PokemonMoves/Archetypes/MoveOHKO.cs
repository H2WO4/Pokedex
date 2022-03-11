using Pokedex.Enums;

namespace Pokedex.Models.PokemonMoves.Archetypes
{
	public class MoveOHKO : PokemonMove
	{
		public MoveOHKO
		(
			string name,
			MoveClass class_,
			int? accuracy,
			int maxPp,
			int priority,
			PokeType type
		) : base(name, class_, null, accuracy, maxPp, priority, type) { }

		public override void DoAction(Pokemon target, Trainer owner, Pokemon caster, Trainer origin, Combat context)
			=> target.DoKO(owner, context);
	}
}