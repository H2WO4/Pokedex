using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveIcePunch : PokeMove
	{
		public MoveIcePunch() : base(
			"Ice-Punch",
			MoveClass.Physical,
			75, 100, // Pow & Acc
			15, 0, // PP & Priority
			TypeIce.Singleton
		)
		{ }
	}
}