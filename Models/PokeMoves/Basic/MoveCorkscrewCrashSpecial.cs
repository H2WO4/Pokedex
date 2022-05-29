using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCorkscrewCrashSpecial : PokeMove
{
    public MoveCorkscrewCrashSpecial()
        : base("Corkscrew Crash  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeSteel.Singleton) { }
}