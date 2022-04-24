using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveShadowPunch : PokeMove
{
    public MoveShadowPunch()
        : base("Shadow-Punch",
               MoveClass.Physical,
               60, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeGhost.Singleton) { }
}