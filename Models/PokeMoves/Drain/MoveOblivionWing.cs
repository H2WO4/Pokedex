using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveOblivionWing : PokeMove, IM_Drain
{
    public int DrainPower
        => 75;

    public MoveOblivionWing()
        : base("Oblivion Wing",
               MoveClass.Special,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeFlying.Singleton) { }
}