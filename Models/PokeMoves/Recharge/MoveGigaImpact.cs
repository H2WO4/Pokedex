using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveGigaImpact : PokeMove, IM_StatusEffectRecoil<RechargeEffect>
{
    public MoveGigaImpact()
        : base("Giga Impact",
               MoveClass.Physical,
               150, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeNormal.Singleton) { }
}