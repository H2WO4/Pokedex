using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSmog : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 40;

    public MoveSmog()
        : base("Smog",
               MoveClass.Special,
               30, 70, // Pow & Acc
               20, 0, // PP & Priority
               TypePoison.Singleton) { }
}