using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveKarateChop : PokeMove
{
    public MoveKarateChop()
        : base("Karate-Chop",
               MoveClass.Physical,
               50, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypeFighting.Singleton) { }
}