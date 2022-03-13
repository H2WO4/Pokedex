using Pokedex.Enums;

namespace Pokedex.Models.PokemonMoves.Archetypes
{
	public abstract class MoveSelf : PokeMove
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

		protected override List<Pokemon> GetTargets()
			=> new List<Pokemon> { this.Caster };
	}
}