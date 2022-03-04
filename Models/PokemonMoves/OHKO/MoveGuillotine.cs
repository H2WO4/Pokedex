using Pokedex.Enums;
using Pokedex.Models.PokemonMoves.Archetypes;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves
{
	public class MoveGuillotine : MoveOHKO
	{
		public MoveGuillotine() : base(
			"Guillotine",
			MoveClass.Physical,
			30, // Acc
			5, 0, // PP & Priority
			TypeNormal.Singleton
		)
		{ }
	}
}