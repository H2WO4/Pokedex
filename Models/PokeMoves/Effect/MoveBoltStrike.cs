using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveBoltStrike : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 20;

    public MoveBoltStrike()
        : base("Bolt Strike",
               MoveClass.Physical,
               130, 85, // Pow & Acc
               5, 0, // PP & Priority
               TypeElectric.Singleton) { }
}