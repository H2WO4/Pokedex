using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSubzeroSlammerSpecial : PokeMove
{
    public MoveSubzeroSlammerSpecial()
        : base("Subzero Slammer  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeIce.Singleton) { }
}