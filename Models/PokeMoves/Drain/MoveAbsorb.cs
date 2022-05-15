using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveAbsorb : PokeMove, I_Drain
{
    public int DrainPower
        => 50;

    public MoveAbsorb()
        : base("Absorb",
               MoveClass.Special,
               20, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypeGrass.Singleton) { }
}