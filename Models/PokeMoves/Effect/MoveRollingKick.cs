using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveRollingKick : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveRollingKick()
        : base("Rolling Kick",
               MoveClass.Physical,
               60, 85, // Pow & Acc
               15, 0, // PP & Priority
               TypeFighting.Singleton) { }
}