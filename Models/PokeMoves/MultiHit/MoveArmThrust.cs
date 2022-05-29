using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveArmThrust : PokeMove, IM_MultiHit
{
    public MoveArmThrust()
        : base("Arm Thrust",
               MoveClass.Physical,
               15, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeFighting.Singleton) { }
}