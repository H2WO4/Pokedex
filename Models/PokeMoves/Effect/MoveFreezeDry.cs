using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveFreezeDry : PokeMove, IM_StatusEffectBonus<FreezeEffect>
{
    public int EffectChance
        => 10;

    public MoveFreezeDry()
        : base("Freeze Dry",
               MoveClass.Special,
               70, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeIce.Singleton) { }
}