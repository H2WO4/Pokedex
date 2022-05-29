using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTailSlap : PokeMove, IM_MultiHit
{
    public MoveTailSlap()
        : base("Tail Slap",
               MoveClass.Physical,
               25, 85, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}