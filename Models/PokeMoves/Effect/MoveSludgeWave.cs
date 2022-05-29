using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSludgeWave : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 10;

    public MoveSludgeWave()
        : base("Sludge Wave",
               MoveClass.Special,
               95, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypePoison.Singleton) { }
}