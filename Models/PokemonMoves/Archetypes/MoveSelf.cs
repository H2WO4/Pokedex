using Pokedex.Enums;

namespace Pokedex.Models.PokemonMoves.Archetypes
{
	public class MoveSelf : PokemonMove
	{
		public MoveSelf
		(
			string name,
			MoveClass class_,
			int? power,
			int? accuracy,
			int maxPp,
			int priority,
			PokeType type
		) : base(name, class_, power, accuracy, maxPp, priority, type) { }

		public override List<(Trainer player, Pokemon pokemon)> GetTargets(Pokemon caster, Trainer origin, Combat context)
			=> new List<(Trainer player, Pokemon pokemon)> { (origin, caster) };
	}
}