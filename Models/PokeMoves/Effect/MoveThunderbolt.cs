using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveThunderbolt : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 10;

    public MoveThunderbolt()
        : base("Thunderbolt",
               MoveClass.Special,
               90, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeElectric.Singleton) { }
}