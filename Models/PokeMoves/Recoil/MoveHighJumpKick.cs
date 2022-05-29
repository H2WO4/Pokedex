using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHighJumpKick : PokeMove, IM_Recoil
{
    public int RecoilPower
        => 0;

    public MoveHighJumpKick()
        : base("High Jump Kick",
               MoveClass.Physical,
               130, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeFighting.Singleton) { }
}