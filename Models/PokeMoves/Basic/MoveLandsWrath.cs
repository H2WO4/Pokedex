using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLandsWrath : PokeMove
{
    public MoveLandsWrath()
        : base("Lands Wrath",
               MoveClass.Physical,
               90, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeGround.Singleton) { }
}