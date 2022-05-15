using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHighJumpKick : PokeMove
{
    public MoveHighJumpKick()
        : base("High Jump Kick",
               MoveClass.Physical,
               130, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeFighting.Singleton) { }
}