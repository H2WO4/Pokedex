using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveStokedSparksurfer : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 100;

    public MoveStokedSparksurfer()
        : base("Stoked Sparksurfer",
               MoveClass.Special,
               175, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeElectric.Singleton) { }
}