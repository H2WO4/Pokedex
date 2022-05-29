using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveCrossPoison : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 10;

    public MoveCrossPoison()
        : base("Cross Poison",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypePoison.Singleton) { }
}