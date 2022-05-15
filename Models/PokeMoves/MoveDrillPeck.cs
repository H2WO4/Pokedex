using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDrillPeck : PokeMove
{
    public MoveDrillPeck()
        : base("Drill Peck",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeFlying.Singleton) { }
}