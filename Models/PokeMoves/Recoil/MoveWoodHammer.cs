using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveWoodHammer : PokeMove, IM_Recoil
{
    public int RecoilPower
        => 33;

    public MoveWoodHammer()
        : base("Wood Hammer",
               MoveClass.Physical,
               120, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGrass.Singleton) { }
}