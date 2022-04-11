using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.PokemonMoves.Archetypes
{
	public abstract class MoveSelf : PokeMove
	{
		protected MoveSelf
		(
			string name,
			MoveClass @class,
			int? power,
			int? accuracy,
			int maxPp,
			int priority,
			PokeType type
		) : base(name, @class, power, accuracy, maxPp, priority, type) { }

		protected override List<I_Battler> GetTargets()
			=> new() { Caster };
	}
}