using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTectonicRagePhysical : PokeMove
{
    public MoveTectonicRagePhysical()
        : base("Tectonic Rage  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeGround.Singleton) { }
}