using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSludge : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 30;

    public MoveSludge()
        : base("Sludge",
               MoveClass.Special,
               65, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypePoison.Singleton) { }
}