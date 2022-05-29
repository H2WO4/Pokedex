using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveBlueFlare : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 20;

    public MoveBlueFlare()
        : base("Blue Flare",
               MoveClass.Special,
               130, 85, // Pow & Acc
               5, 0, // PP & Priority
               TypeFire.Singleton) { }
}