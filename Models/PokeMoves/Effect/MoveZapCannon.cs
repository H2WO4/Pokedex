using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveZapCannon : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 100;

    public MoveZapCannon()
        : base("Zap Cannon",
               MoveClass.Special,
               120, 50, // Pow & Acc
               5, 0, // PP & Priority
               TypeElectric.Singleton) { }
}