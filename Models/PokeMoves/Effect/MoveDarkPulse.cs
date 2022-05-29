using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveDarkPulse : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 20;

    public MoveDarkPulse()
        : base("Dark Pulse",
               MoveClass.Special,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeDark.Singleton) { }
}