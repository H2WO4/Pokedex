using Pokedex.Enums;
using Pokedex.Models.Events;
using Pokedex.Models.PokemonTypes;
using Pokedex.Models.Weathers;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveExtremeSpeed : PokemonMove
	{
		public MoveExtremeSpeed() : base(
			"Extreme Speed",
			MoveClass.Special,
			80, 100, // Pow & Acc
			5, 2, // PP & Priority
			TypeElectric.Singleton
		) {}
    }
}