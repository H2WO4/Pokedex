using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveMegaPunch : PokemonMove
	{
		public MoveMegaPunch() : base(
			"Mega-Punch",
			MoveClass.Physical,
			80, 85, // Pow & Acc
			20, 0, // PP & Priority
			TypeNormal.Singleton
		) {}
	}
}