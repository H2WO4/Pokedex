using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveTwister : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 20;

    public MoveTwister()
        : base("Twister",
               MoveClass.Special,
               40, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeDragon.Singleton) { }
}