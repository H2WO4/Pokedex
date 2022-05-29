using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveShadowClaw : PokeMove
{
    public MoveShadowClaw()
        : base("Shadow Claw",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGhost.Singleton) { }
}