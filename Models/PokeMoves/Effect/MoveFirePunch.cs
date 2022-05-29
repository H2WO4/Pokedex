using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveFirePunch : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 10;

    public MoveFirePunch()
        : base("Fire Punch",
               MoveClass.Physical,
               75, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeFire.Singleton) { }
}