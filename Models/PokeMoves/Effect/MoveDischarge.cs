using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveDischarge : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 30;

    public MoveDischarge()
        : base("Discharge",
               MoveClass.Special,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeElectric.Singleton) { }
}