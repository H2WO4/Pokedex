using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveThunder : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 30;

    public MoveThunder()
        : base("Thunder",
               MoveClass.Special,
               110, 70, // Pow & Acc
               10, 0, // PP & Priority
               TypeElectric.Singleton) { }
}