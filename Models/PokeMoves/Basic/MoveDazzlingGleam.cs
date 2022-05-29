using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDazzlingGleam : PokeMove
{
    public MoveDazzlingGleam()
        : base("Dazzling Gleam",
               MoveClass.Special,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeFairy.Singleton) { }
}