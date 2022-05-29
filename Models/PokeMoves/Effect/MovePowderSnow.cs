using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MovePowderSnow : PokeMove, IM_StatusEffectBonus<FreezeEffect>
{
    public int EffectChance
        => 10;

    public MovePowderSnow()
        : base("Powder Snow",
               MoveClass.Special,
               40, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypeIce.Singleton) { }
}