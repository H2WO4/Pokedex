using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveQuickAttack : PokeMove
{
    public MoveQuickAttack()
        : base("Quick Attack",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               30, 1, // PP & Priority
               TypeNormal.Singleton) { }
}