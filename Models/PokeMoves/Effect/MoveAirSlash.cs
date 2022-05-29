using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveAirSlash : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveAirSlash()
        : base("Air Slash",
               MoveClass.Special,
               75, 95, // Pow & Acc
               15, 0, // PP & Priority
               TypeFlying.Singleton) { }
}