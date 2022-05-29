using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAeroblast : PokeMove
{
    public MoveAeroblast()
        : base("Aeroblast",
               MoveClass.Special,
               100, 95, // Pow & Acc
               5, 0, // PP & Priority
               TypeFlying.Singleton) { }
}