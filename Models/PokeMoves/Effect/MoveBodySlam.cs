using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveBodySlam : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 30;

    public MoveBodySlam()
        : base("Body Slam",
               MoveClass.Physical,
               85, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}