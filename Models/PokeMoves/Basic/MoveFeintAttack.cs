using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFeintAttack : PokeMove
{
    public MoveFeintAttack()
        : base("Feint Attack",
               MoveClass.Physical,
               60, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeDark.Singleton) { }
}