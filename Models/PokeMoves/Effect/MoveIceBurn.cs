using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveIceBurn : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 30;

    public MoveIceBurn()
        : base("Ice Burn",
               MoveClass.Special,
               140, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeIce.Singleton) { }
}