using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMegahorn : PokeMove
{
    public MoveMegahorn()
        : base("Megahorn",
               MoveClass.Physical,
               120, 85, // Pow & Acc
               10, 0, // PP & Priority
               TypeBug.Singleton) { }
}