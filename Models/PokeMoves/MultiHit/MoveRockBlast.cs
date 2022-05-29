using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveRockBlast : PokeMove, IM_MultiHit
{
    public MoveRockBlast()
        : base("Rock Blast",
               MoveClass.Physical,
               25, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeRock.Singleton) { }
}