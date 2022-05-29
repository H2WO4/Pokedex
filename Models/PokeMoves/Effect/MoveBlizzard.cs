using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveBlizzard : PokeMove, IM_StatusEffectBonus<FreezeEffect>
{
    public int EffectChance
        => 10;

    public MoveBlizzard()
        : base("Blizzard",
               MoveClass.Special,
               110, 70, // Pow & Acc
               5, 0, // PP & Priority
               TypeIce.Singleton) { }
}