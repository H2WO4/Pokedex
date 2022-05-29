using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveVitalThrow : PokeMove
{
    public MoveVitalThrow()
        : base("Vital Throw",
               MoveClass.Physical,
               70, null, // Pow & Acc
               10, -1, // PP & Priority
               TypeFighting.Singleton) { }
}