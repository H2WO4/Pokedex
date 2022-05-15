using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveScratch : PokeMove
{
    public MoveScratch()
        : base("Scratch",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               35, 0, // PP & Priority
               TypeNormal.Singleton) { }
}