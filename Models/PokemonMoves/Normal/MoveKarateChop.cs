using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveKarateChop : PokemonMove
	{
		public MoveKarateChop() : base(
			"Karate-Chop",
			MoveClass.Physical,
			50, 100, // Pow & Acc
			25, 0, // PP & Priority
			TypeFighting.Singleton
		)
		{ }
	}
}