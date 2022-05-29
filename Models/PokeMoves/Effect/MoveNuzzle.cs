using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveNuzzle : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 100;

    public MoveNuzzle()
        : base("Nuzzle",
               MoveClass.Physical,
               20, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeElectric.Singleton) { }
}