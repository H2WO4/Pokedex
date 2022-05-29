using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMachPunch : PokeMove
{
    public MoveMachPunch()
        : base("Mach Punch",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               30, 1, // PP & Priority
               TypeFighting.Singleton) { }
}