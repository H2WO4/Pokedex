using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBide : PokeMove
{
    public MoveBide()
        : base("Bide",
               MoveClass.Physical,
               null, null, // Pow & Acc
               10, 1, // PP & Priority
               TypeNormal.Singleton) { }
}