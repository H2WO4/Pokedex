using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSludgeBomb : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 30;

    public MoveSludgeBomb()
        : base("Sludge Bomb",
               MoveClass.Special,
               90, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypePoison.Singleton) { }
}