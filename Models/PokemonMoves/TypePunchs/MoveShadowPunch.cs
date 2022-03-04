using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveShadowPunch : PokemonMove
	{
		public MoveShadowPunch() : base(
			"Shadow-Punch",
			MoveClass.Physical,
			60, null, // Pow & Acc
			20, 0, // PP & Priority
			TypeGhost.Singleton
		)
		{ }
	}
}