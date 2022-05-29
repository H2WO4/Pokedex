using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveRockSlide : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveRockSlide()
        : base("Rock Slide",
               MoveClass.Physical,
               75, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeRock.Singleton) { }
}