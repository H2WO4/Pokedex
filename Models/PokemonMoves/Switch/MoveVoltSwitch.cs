using Pokedex.Enums;
using Pokedex.Models.PokemonMoves.Archetypes;
using Pokedex.Models.PokemonTypes;


namespace Pokedex.Models.PokemonMoves;

public class MoveVoltSwitch : MoveSwitch
{
	public MoveVoltSwitch()
		: base("Volt Switch",
			   MoveClass.Special,
			   70, 100, // Pow & Acc
			   20, 0, // PP & Priority
			   TypeElectric.Singleton) { }
}