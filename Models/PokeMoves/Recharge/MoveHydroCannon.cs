using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveHydroCannon : PokeMove, IM_StatusEffectRecoil<RechargeEffect>
{
    public MoveHydroCannon()
        : base("Hydro Cannon",
               MoveClass.Special,
               150, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeWater.Singleton) { }
}