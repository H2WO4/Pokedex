using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHeadCharge : PokeMove, IM_Recoil
{
    public int RecoilPower
        => 25;

    public MoveHeadCharge()
        : base("Head Charge",
               MoveClass.Physical,
               120, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}