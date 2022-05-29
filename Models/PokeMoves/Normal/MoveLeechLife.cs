using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLeechLife : PokeMove, IM_Drain
{
    public int DrainPower
        => 50;

    public MoveLeechLife()
        : base("Leech Life",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeBug.Singleton) { }
}