using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHornLeech : PokeMove, IM_Drain
{
    public int DrainPower
        => 50;

    public MoveHornLeech()
        : base("Horn Leech",
               MoveClass.Physical,
               75, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeGrass.Singleton) { }
}