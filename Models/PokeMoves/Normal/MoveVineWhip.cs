using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveVineWhip : PokeMove
{
    public MoveVineWhip()
        : base("Vine Whip",
               MoveClass.Physical,
               45, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypeGrass.Singleton) { }
}