using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDevastatingDrakeSpecial : PokeMove
{
    public MoveDevastatingDrakeSpecial()
        : base("Devastating Drake  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeDragon.Singleton) { }
}