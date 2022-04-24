using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveDoubleSlap : PokeMove, I_MultiHit
{
    public MoveDoubleSlap()
        : base("Double Slap",
               MoveClass.Physical,
               15, 85, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}