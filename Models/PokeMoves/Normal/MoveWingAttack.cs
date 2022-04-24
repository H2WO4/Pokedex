using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveWingAttack : PokeMove
{
    public MoveWingAttack()
        : base("Wing Attack",
               MoveClass.Physical,
               60, 100, // Pow & Acc
               35, 0, // PP & Priority
               TypeFlying.Singleton) { }
}