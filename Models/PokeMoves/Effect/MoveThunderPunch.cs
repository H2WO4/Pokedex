using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveThunderPunch : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 10;

    public MoveThunderPunch()
        : base("Thunder Punch",
               MoveClass.Physical,
               75, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeElectric.Singleton) { }
}