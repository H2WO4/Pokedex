using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveBounce : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 30;

    public MoveBounce()
        : base("Bounce",
               MoveClass.Physical,
               85, 85, // Pow & Acc
               5, 0, // PP & Priority
               TypeFlying.Singleton) { }
}