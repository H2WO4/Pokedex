using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveShadowSneak : PokeMove
{
    public MoveShadowSneak()
        : base("Shadow Sneak",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               30, 1, // PP & Priority
               TypeGhost.Singleton) { }
}