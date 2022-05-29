using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHydroVortexSpecial : PokeMove
{
    public MoveHydroVortexSpecial()
        : base("Hydro Vortex  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeWater.Singleton) { }
}