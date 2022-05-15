using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveEggBomb : PokeMove
{
    public MoveEggBomb()
        : base("Egg Bomb",
               MoveClass.Physical,
               100, 75, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}