using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveEmber : PokeMove, I_EffectChance<BurnEffect>
{
    public int EffectChance
        => 10;

    public MoveEmber()
        : base("Ember",
               MoveClass.Special,
               40, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypeFire.Singleton) { }
}