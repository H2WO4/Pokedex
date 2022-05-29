using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveRockThrow : PokeMove
{
    public MoveRockThrow()
        : base("Rock Throw",
               MoveClass.Physical,
               50, 90, // Pow & Acc
               15, 0, // PP & Priority
               TypeRock.Singleton) { }
}