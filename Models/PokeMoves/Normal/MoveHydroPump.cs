using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveHydroPump : PokeMove
{
    public MoveHydroPump()
        : base("Hydro Pump",
               MoveClass.Special,
               110, 80, // Pow & Acc
               5, 0, // PP & Priority
               TypeWater.Singleton) { }
}