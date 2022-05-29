using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveOriginPulse : PokeMove
{
    public MoveOriginPulse()
        : base("Origin Pulse",
               MoveClass.Special,
               110, 85, // Pow & Acc
               10, 0, // PP & Priority
               TypeWater.Singleton) { }
}