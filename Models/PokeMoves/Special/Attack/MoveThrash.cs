using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveThrash : PokeMove
{
    public MoveThrash()
        : base("Thrash",
               MoveClass.Physical,
               120, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}