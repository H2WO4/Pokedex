using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveBlazeKick : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 10;

    public MoveBlazeKick()
        : base("Blaze Kick",
               MoveClass.Physical,
               85, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeFire.Singleton) { }
}