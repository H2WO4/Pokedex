using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveTwineedle : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 20;

    public MoveTwineedle()
        : base("Twineedle",
               MoveClass.Physical,
               25, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeBug.Singleton) { }
}