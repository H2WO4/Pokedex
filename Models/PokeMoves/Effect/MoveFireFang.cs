using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveFireFang : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 10;

    public MoveFireFang()
        : base("Fire Fang",
               MoveClass.Physical,
               65, 95, // Pow & Acc
               15, 0, // PP & Priority
               TypeFire.Singleton) { }
}