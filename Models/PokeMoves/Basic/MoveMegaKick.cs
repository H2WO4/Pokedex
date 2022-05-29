using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMegaKick : PokeMove
{
    public MoveMegaKick()
        : base("Mega Kick",
               MoveClass.Physical,
               120, 75, // Pow & Acc
               5, 0, // PP & Priority
               TypeNormal.Singleton) { }
}