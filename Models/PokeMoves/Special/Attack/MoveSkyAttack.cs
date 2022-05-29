using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSkyAttack : PokeMove
{
    public MoveSkyAttack()
        : base("Sky Attack",
               MoveClass.Physical,
               140, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeFlying.Singleton) { }
}