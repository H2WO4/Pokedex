using Pokedex.Enums;
using Pokedex.Models.Events;
using Pokedex.Models.PokemonTypes;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveQuickAttack : PokemonMove
	{
		public MoveQuickAttack() : base(
			"Quick Attack",
			MoveClass.Special,
			40, 100, // Pow & Acc
			30, 1, // PP & Priority
			TypeElectric.Singleton
		) {}
    }
}