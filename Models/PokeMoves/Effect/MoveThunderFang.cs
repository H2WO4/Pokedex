using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveThunderFang : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 10;

    public MoveThunderFang()
        : base("Thunder Fang",
               MoveClass.Physical,
               65, 95, // Pow & Acc
               15, 0, // PP & Priority
               TypeElectric.Singleton) { }
}