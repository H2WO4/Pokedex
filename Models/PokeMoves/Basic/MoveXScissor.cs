using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveXScissor : PokeMove
{
    public MoveXScissor()
        : base("X Scissor",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeBug.Singleton) { }
}