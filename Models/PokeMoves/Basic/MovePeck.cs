using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePeck : PokeMove
{
    public MovePeck()
        : base("Peck",
               MoveClass.Physical,
               35, 100, // Pow & Acc
               35, 0, // PP & Priority
               TypeFlying.Singleton) { }
}