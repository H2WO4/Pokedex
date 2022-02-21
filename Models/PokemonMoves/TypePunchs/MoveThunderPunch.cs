using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveThunderPunch : PokemonMove
	{
		public MoveThunderPunch() : base(
			"Thunder-Punch",
			MoveClass.Physical,
			75, 100, // Pow & Acc
			15, 0, // PP & Priority
			TypeElectric.Singleton
		) {}
	}
}