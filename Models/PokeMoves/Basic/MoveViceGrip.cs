using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveViceGrip : PokeMove
{
    public MoveViceGrip()
        : base("Vice Grip",
               MoveClass.Physical,
               55, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }
}