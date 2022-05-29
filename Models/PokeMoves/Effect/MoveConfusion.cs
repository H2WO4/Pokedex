using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveConfusion : PokeMove, IM_StatusEffectBonus<ConfusionEffect>
{
    public int EffectChance
        => 10;

    public MoveConfusion()
        : base("Confusion",
               MoveClass.Special,
               50, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypePsychic.Singleton) { }
}