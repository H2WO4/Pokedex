using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveStoneEdge : PokeMove
{
    public MoveStoneEdge()
        : base("Stone Edge",
               MoveClass.Physical,
               100, 80, // Pow & Acc
               5, 0, // PP & Priority
               TypeRock.Singleton) { }
}