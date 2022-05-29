using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveParabolicCharge : PokeMove, IM_Drain
{
    public int DrainPower
        => 50;

    public MoveParabolicCharge()
        : base("Parabolic Charge",
               MoveClass.Special,
               65, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeElectric.Singleton) { }
}