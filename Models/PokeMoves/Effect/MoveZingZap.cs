using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveZingZap : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveZingZap()
        : base("Zing Zap",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeElectric.Singleton) { }
}