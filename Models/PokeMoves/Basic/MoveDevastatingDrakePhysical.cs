using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDevastatingDrakePhysical : PokeMove
{
    public MoveDevastatingDrakePhysical()
        : base("Devastating Drake  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeDragon.Singleton) { }
}