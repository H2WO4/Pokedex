using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAccelerock : PokeMove
{
    public MoveAccelerock()
        : base("Accelerock",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               20, 1, // PP & Priority
               TypeRock.Singleton) { }
}