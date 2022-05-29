using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBreakneckBlitzPhysical : PokeMove
{
    public MoveBreakneckBlitzPhysical()
        : base("Breakneck Blitz  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeNormal.Singleton) { }
}