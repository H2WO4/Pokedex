using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveWaterfall : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 20;

    public MoveWaterfall()
        : base("Waterfall",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeWater.Singleton) { }
}