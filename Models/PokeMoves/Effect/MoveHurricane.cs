using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveHurricane : PokeMove, IM_StatusEffectBonus<ConfusionEffect>
{
    public int EffectChance
        => 30;

    public MoveHurricane()
        : base("Hurricane",
               MoveClass.Special,
               110, 70, // Pow & Acc
               10, 0, // PP & Priority
               TypeFlying.Singleton) { }
}