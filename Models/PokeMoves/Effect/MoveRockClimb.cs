using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveRockClimb : PokeMove, IM_StatusEffectBonus<ConfusionEffect>
{
    public int EffectChance
        => 20;

    public MoveRockClimb()
        : base("Rock Climb",
               MoveClass.Physical,
               90, 85, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}