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
			PokemonType type
		) : base(name, class_, power, accuracy, maxPp, priority, type) { }

		public override List<(Player player, Pokemon pokemon)> GetTargets(Pokemon caster, Player origin, CombatInstance context)
			=> new List<(Player player, Pokemon pokemon)> { (origin, caster) };
	}
}