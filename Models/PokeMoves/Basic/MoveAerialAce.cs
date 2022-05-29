using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAerialAce : PokeMove
{
    public MoveAerialAce()
        : base("Aerial Ace",
               MoveClass.Physical,
               60, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeFlying.Singleton) { }
}