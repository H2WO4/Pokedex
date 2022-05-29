using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDrillRun : PokeMove
{
    public MoveDrillRun()
        : base("Drill Run",
               MoveClass.Physical,
               80, 95, // Pow & Acc
               10, 0, // PP & Priority
               TypeGround.Singleton) { }
}