using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveContinentalCrushPhysical : PokeMove
{
    public MoveContinentalCrushPhysical()
        : base("Continental Crush  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeRock.Singleton) { }
}