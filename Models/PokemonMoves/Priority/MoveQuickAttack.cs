using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveQuickAttack : PokemonMove
	{
		public MoveQuickAttack() : base(
			"Quick Attack",
			MoveClass.Physical,
			40, 100, // Pow & Acc
			30, 1, // PP & Priority
			TypeNormal.Singleton
		) {}
    }
}