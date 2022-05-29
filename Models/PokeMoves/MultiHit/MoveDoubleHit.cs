using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDoubleHit : PokeMove, IM_DoubleHit
{
    public MoveDoubleHit()
        : base("Double Hit",
               MoveClass.Physical,
               35, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}