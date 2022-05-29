using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveAstonish : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveAstonish()
        : base("Astonish",
               MoveClass.Physical,
               30, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGhost.Singleton) { }
}