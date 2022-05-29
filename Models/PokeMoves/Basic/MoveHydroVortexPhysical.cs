using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHydroVortexPhysical : PokeMove
{
    public MoveHydroVortexPhysical()
        : base("Hydro Vortex  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeWater.Singleton) { }
}