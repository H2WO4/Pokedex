using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveIceFang : PokeMove, IM_StatusEffectBonus<FreezeEffect>
{
    public int EffectChance
        => 10;

    public MoveIceFang()
        : base("Ice Fang",
               MoveClass.Physical,
               65, 95, // Pow & Acc
               15, 0, // PP & Priority
               TypeIce.Singleton) { }
}