using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveFireBlast : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 10;

    public MoveFireBlast()
        : base("Fire Blast",
               MoveClass.Special,
               110, 85, // Pow & Acc
               5, 0, // PP & Priority
               TypeFire.Singleton) { }
}