using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveDoubleKick : PokeMove, I_DoubleHit
{
    public MoveDoubleKick()
        : base("Double Kick",
               MoveClass.Physical,
               30, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeFighting.Singleton) { }
}