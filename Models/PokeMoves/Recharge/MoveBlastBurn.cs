using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveBlastBurn : PokeMove, IM_StatusEffectRecoil<RechargeEffect>
{
    public MoveBlastBurn()
        : base("Blast Burn",
               MoveClass.Special,
               150, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeFire.Singleton) { }
}