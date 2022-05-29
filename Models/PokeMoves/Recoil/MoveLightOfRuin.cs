using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLightOfRuin : PokeMove, IM_Recoil
{
    public int RecoilPower
        => 50;

    public MoveLightOfRuin()
        : base("Light Of Ruin",
               MoveClass.Special,
               140, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeFairy.Singleton) { }
}