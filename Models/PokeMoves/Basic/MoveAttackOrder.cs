using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAttackOrder : PokeMove
{
    public MoveAttackOrder()
        : base("Attack Order",
               MoveClass.Physical,
               90, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeBug.Singleton) { }
}