using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHornAttack : PokeMove
{
    public MoveHornAttack()
        : base("Horn Attack",
               MoveClass.Physical,
               65, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypeNormal.Singleton) { }
}