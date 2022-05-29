using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePulverizingPancake : PokeMove
{
    public MovePulverizingPancake()
        : base("Pulverizing Pancake",
               MoveClass.Physical,
               210, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeNormal.Singleton) { }
}