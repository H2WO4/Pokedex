using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSubzeroSlammerPhysical : PokeMove
{
    public MoveSubzeroSlammerPhysical()
        : base("Subzero Slammer  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeIce.Singleton) { }
}