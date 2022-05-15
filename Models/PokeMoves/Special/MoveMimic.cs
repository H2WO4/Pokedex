using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMimic : PokeMove
{
    public MoveMimic()
        : base("Mimic",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}