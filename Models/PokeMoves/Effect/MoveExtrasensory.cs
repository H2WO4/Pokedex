using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveExtrasensory : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 10;

    public MoveExtrasensory()
        : base("Extrasensory",
               MoveClass.Special,
               80, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypePsychic.Singleton) { }
}