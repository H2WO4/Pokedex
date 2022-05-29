using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveWaterPulse : PokeMove, IM_StatusEffectBonus<ConfusionEffect>
{
    public int EffectChance
        => 20;

    public MoveWaterPulse()
        : base("Water Pulse",
               MoveClass.Special,
               60, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeWater.Singleton) { }
}