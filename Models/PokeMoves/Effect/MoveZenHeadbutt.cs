using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveZenHeadbutt : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 20;

    public MoveZenHeadbutt()
        : base("Zen Headbutt",
               MoveClass.Physical,
               80, 90, // Pow & Acc
               15, 0, // PP & Priority
               TypePsychic.Singleton) { }
}