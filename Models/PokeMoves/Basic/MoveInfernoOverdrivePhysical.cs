using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveInfernoOverdrivePhysical : PokeMove
{
    public MoveInfernoOverdrivePhysical()
        : base("Inferno Overdrive  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeFire.Singleton) { }
}