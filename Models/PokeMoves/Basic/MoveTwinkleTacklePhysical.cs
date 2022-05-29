using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTwinkleTacklePhysical : PokeMove
{
    public MoveTwinkleTacklePhysical()
        : base("Twinkle Tackle  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeFairy.Singleton) { }
}