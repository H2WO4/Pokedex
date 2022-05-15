using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSheerCold : PokeMove, IM_OHKO
{
    public MoveSheerCold()
        : base("Sheer Cold",
               MoveClass.Special,
               null, 30, // Pow & Acc
               5, 0, // PP & Priority
               TypeIce.Singleton) { }
}