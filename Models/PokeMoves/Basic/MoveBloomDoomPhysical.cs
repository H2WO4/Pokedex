using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBloomDoomPhysical : PokeMove
{
    public MoveBloomDoomPhysical()
        : base("Bloom Doom  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeGrass.Singleton) { }
}