using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MovePsybeam : PokeMove, IM_StatusEffectBonus<ConfusionEffect>
{
    public int EffectChance
        => 10;

    public MovePsybeam()
        : base("Psybeam",
               MoveClass.Special,
               65, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypePsychic.Singleton) { }
}