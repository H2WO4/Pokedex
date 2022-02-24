using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveGuillotine : PokemonMove
	{
		public MoveGuillotine() : base(
			"Guillotine",
			MoveClass.Physical,
			null, 30, // Pow & Acc
			5, 0, // PP & Priority
			TypeNormal.Singleton
		) {}

		public override void DoAction(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context) =>
			target.DoKO(owner, context);
	}
}