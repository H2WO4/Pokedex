using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveConstrict : PokeMove
{
    public MoveConstrict()
        : base("Constrict",
               MoveClass.Physical,
               10, 100, // Pow & Acc
               35, 0, // PP & Priority
               TypeNormal.Singleton) { }
}