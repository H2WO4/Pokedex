using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMegaPunch : PokeMove
{
    public MoveMegaPunch()
        : base("Mega Punch",
               MoveClass.Physical,
               80, 85, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}