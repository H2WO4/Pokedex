using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHeadSmash : PokeMove, IM_Recoil
{
    public int RecoilPower
        => 50;

    public MoveHeadSmash()
        : base("Head Smash",
               MoveClass.Physical,
               150, 80, // Pow & Acc
               5, 0, // PP & Priority
               TypeRock.Singleton) { }
}