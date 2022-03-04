using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MovePound : PokemonMove
	{
		public MovePound() : base(
			"Pound",
			MoveClass.Physical,
			40, 100, // Pow & Acc
			35, 0, // PP & Priority
			TypeNormal.Singleton
		)
		{ }
	}
}