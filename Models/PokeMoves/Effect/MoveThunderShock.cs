using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveThunderShock : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 10;

    public MoveThunderShock()
        : base("Thunder Shock",
               MoveClass.Special,
               40, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeElectric.Singleton) { }
}