using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveRoarOfTime : PokeMove, IM_StatusEffectRecoil<RechargeEffect>
{
    public MoveRoarOfTime()
        : base("Roar Of Time",
               MoveClass.Special,
               150, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeDragon.Singleton) { }
}