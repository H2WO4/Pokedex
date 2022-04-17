using Pokedex.Enums;
using Pokedex.Models.PokemonMoves.Archetypes;
using Pokedex.Models.PokemonTypes;


namespace Pokedex.Models.PokemonMoves;

public class MoveUTurn : MoveSwitch
{
	public MoveUTurn()
		: base("U-Turn",
			   MoveClass.Physical,
			   70, 100, // Pow & Acc
			   20, 0, // PP & Priority
			   TypeNormal.Singleton) { }
}