using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBind : PokeMove
{
    public MoveBind()
        : base("Bind",
               MoveClass.Physical,
               15, 85, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}