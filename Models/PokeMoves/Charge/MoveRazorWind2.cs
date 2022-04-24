using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;

namespace Pokedex.Models.PokeMoves;

public class MoveRazorWind2 : PokeMove, I_Switch, I_Effect<ParalysisEffect>
{
    public MoveRazorWind2()
        : base("Razor Wind",
               MoveClass.Special,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }

    public int EffectChance
        => 30;
}