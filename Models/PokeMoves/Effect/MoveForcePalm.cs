using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveForcePalm : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 30;

    public MoveForcePalm()
        : base("Force Palm",
               MoveClass.Physical,
               60, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeFighting.Singleton) { }
}