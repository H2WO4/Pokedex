using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveContinentalCrushSpecial : PokeMove
{
    public MoveContinentalCrushSpecial()
        : base("Continental Crush  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeRock.Singleton) { }
}