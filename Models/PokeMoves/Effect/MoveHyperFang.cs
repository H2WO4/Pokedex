using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveHyperFang : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 10;

    public MoveHyperFang()
        : base("Hyper Fang",
               MoveClass.Physical,
               80, 90, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}