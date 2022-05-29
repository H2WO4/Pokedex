using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAirCutter : PokeMove
{
    public MoveAirCutter()
        : base("Air Cutter",
               MoveClass.Special,
               60, 95, // Pow & Acc
               25, 0, // PP & Priority
               TypeFlying.Singleton) { }
}