using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveDynamicPunch : PokeMove, IM_StatusEffectBonus<ConfusionEffect>
{
    public int EffectChance
        => 100;

    public MoveDynamicPunch()
        : base("Dynamic Punch",
               MoveClass.Physical,
               100, 50, // Pow & Acc
               5, 0, // PP & Priority
               TypeFighting.Singleton) { }
}