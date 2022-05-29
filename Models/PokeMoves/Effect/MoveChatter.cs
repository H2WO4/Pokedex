using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveChatter : PokeMove, IM_StatusEffectBonus<ConfusionEffect>
{
    public int EffectChance
        => 100;

    public MoveChatter()
        : base("Chatter",
               MoveClass.Special,
               65, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeFlying.Singleton) { }
}