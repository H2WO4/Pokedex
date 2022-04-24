using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveDoubleEdge : PokeMove, I_Recoil
{
    public int RecoilPower
        => 33;

    public MoveDoubleEdge()
        : base("Double Edge",
               MoveClass.Physical,
               120, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}