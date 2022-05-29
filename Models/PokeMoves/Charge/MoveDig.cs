using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDig : PokeMove
{
    public MoveDig()
        : base("Dig",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeGround.Singleton) { }
}