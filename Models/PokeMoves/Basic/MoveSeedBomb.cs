using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSeedBomb : PokeMove
{
    public MoveSeedBomb()
        : base("Seed Bomb",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGrass.Singleton) { }
}