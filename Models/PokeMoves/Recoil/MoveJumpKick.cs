using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveJumpKick : PokeMove, IM_Recoil
{
    public int RecoilPower
        => 0;

    public MoveJumpKick()
        : base("Jump Kick",
               MoveClass.Physical,
               100, 95, // Pow & Acc
               10, 0, // PP & Priority
               TypeFighting.Singleton) { }
}