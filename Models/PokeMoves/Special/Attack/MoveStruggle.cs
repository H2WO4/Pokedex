using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveStruggle : PokeMove, IM_Recoil
{
    public int RecoilPower
        => 25;

    public override bool IsMeta
        => true;

    public MoveStruggle()
        : base("Struggle",
               MoveClass.Physical,
               50, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeNormal.Singleton) { }
}