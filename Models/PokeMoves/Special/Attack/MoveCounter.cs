using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCounter : PokeMove
{
    public MoveCounter()
        : base("Counter",
               MoveClass.Physical,
               null, 100, // Pow & Acc
               20, -5, // PP & Priority
               TypeFighting.Singleton) { }
}