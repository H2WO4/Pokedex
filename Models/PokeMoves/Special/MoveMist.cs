using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMist : PokeMove
{
    public MoveMist()
        : base("Mist",
               MoveClass.Status,
               null, null, // Pow & Acc
               30, 0, // PP & Priority
               TypeIce.Singleton) { }
}