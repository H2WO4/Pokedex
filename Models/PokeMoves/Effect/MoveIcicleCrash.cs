using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveIcicleCrash : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveIcicleCrash()
        : base("Icicle Crash",
               MoveClass.Physical,
               85, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeIce.Singleton) { }
}