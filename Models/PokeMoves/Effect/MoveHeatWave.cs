using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveHeatWave : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 10;

    public MoveHeatWave()
        : base("Heat Wave",
               MoveClass.Special,
               95, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeFire.Singleton) { }
}