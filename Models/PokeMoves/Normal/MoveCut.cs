using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveCut : PokeMove
{
    public MoveCut()
        : base("Cut",
               MoveClass.Physical,
               50, 95, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }
}