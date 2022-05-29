using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveWildCharge : PokeMove, IM_Recoil
{
    public int RecoilPower
        => 25;

    public MoveWildCharge()
        : base("Wild Charge",
               MoveClass.Physical,
               90, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeElectric.Singleton) { }
}