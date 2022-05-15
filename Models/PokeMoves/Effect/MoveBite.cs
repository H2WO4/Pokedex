using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveBite : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveBite()
        : base("Bite",
               MoveClass.Physical,
               60, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypeDark.Singleton) { }
}