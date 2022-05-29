using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveDragonRush : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 20;

    public MoveDragonRush()
        : base("Dragon Rush",
               MoveClass.Physical,
               100, 75, // Pow & Acc
               10, 0, // PP & Priority
               TypeDragon.Singleton) { }
}