using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveInferno : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 100;

    public MoveInferno()
        : base("Inferno",
               MoveClass.Special,
               100, 50, // Pow & Acc
               5, 0, // PP & Priority
               TypeFire.Singleton) { }
}