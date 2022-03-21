using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.PokemonMoves.Archetypes
{
	public abstract class MoveOHKO : PokeMove
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

		protected override void DoAction(I_Battler target)
			=> target.DoKO();
	}
}