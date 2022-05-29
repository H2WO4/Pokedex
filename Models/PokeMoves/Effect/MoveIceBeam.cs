using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveIceBeam : PokeMove, IM_StatusEffectBonus<FreezeEffect>
{
    public int EffectChance
        => 10;

    public MoveIceBeam()
        : base("Ice Beam",
               MoveClass.Special,
               90, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeIce.Singleton) { }
}