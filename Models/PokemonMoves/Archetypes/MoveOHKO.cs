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

		protected override void DoAction(Pokemon target)
			=> target.DoKO();
	}
}