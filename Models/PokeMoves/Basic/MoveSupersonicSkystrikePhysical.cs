using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSupersonicSkystrikePhysical : PokeMove
{
    public MoveSupersonicSkystrikePhysical()
        : base("Supersonic Skystrike  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeFlying.Singleton) { }
}