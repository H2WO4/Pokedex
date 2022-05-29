using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCrossChop : PokeMove
{
    public MoveCrossChop()
        : base("Cross Chop",
               MoveClass.Physical,
               100, 80, // Pow & Acc
               5, 0, // PP & Priority
               TypeFighting.Singleton) { }
}