using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveRockWrecker : PokeMove, IM_StatusEffectRecoil<RechargeEffect>
{
    public MoveRockWrecker()
        : base("Rock Wrecker",
               MoveClass.Physical,
               150, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeRock.Singleton) { }
}