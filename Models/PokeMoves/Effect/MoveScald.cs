using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveScald : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 30;

    public MoveScald()
        : base("Scald",
               MoveClass.Special,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeWater.Singleton) { }
}