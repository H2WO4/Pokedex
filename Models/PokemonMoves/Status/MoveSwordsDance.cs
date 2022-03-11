using Pokedex.Enums;
using Pokedex.Models.PokemonMoves.Archetypes;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveSwordsDance : MoveSelf
	{
		public MoveSwordsDance() : base(
			"Swords Dance",
			MoveClass.Status,
			null, null, // Pow & Acc
			20, 0, // PP & Priority
			TypeNormal.Singleton
		)
		{ }

		public override void DoAction(Pokemon target, Trainer owner, Pokemon caster, Trainer origin, Combat context)
			=> target.ChangeStatBonuses(2, 0, 0, 0, 0);
	}
}