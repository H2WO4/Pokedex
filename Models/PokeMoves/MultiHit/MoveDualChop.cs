using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDualChop : PokeMove, IM_DoubleHit
{
    public MoveDualChop()
        : base("Dual Chop",
               MoveClass.Physical,
               40, 90, // Pow & Acc
               15, 0, // PP & Priority
               TypeDragon.Singleton) { }
}