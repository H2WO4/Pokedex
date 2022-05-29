using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCorkscrewCrashPhysical : PokeMove
{
    public MoveCorkscrewCrashPhysical()
        : base("Corkscrew Crash  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeSteel.Singleton) { }
}