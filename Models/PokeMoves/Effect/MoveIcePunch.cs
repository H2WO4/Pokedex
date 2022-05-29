using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveIcePunch : PokeMove, IM_StatusEffectBonus<FreezeEffect>
{
    public int EffectChance
        => 10;

    public MoveIcePunch()
        : base("Ice Punch",
               MoveClass.Physical,
               75, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeIce.Singleton) { }
}