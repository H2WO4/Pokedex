using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveNeverEndingNightmarePhysical : PokeMove
{
    public MoveNeverEndingNightmarePhysical()
        : base("Never Ending Nightmare  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeGhost.Singleton) { }
}