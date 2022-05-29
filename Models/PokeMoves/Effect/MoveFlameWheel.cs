using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveFlameWheel : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 10;

    public MoveFlameWheel()
        : base("Flame Wheel",
               MoveClass.Physical,
               60, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypeFire.Singleton) { }
}