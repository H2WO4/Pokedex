using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBraveBird : PokeMove, IM_Recoil
{
    public int RecoilPower
        => 33;

    public MoveBraveBird()
        : base("Brave Bird",
               MoveClass.Physical,
               120, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeFlying.Singleton) { }
}