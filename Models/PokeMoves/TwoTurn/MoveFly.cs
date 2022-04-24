using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveFly : PokeMove
{
    public MoveFly()
        : base("Fly",
               MoveClass.Physical,
               90, 95, // Pow & Acc
               15, 0, // PP & Priority
               TypeFlying.Singleton) { }
}