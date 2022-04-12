using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves;

public class MoveFirePunch : PokeMove
{
	public MoveFirePunch() : base(
		"Fire-Punch",
		MoveClass.Physical,
		75, 100, // Pow & Acc
		15, 0, // PP & Priority
		TypeFire.Singleton
	)
	{ }
}