using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDrainingKiss : PokeMove, IM_Drain
{
    public int DrainPower
        => 75;

    public MoveDrainingKiss()
        : base("Draining Kiss",
               MoveClass.Special,
               50, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeFairy.Singleton) { }
}