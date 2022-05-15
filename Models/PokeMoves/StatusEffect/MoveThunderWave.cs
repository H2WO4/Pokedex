using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveThunderWave : PokeMove, IM_StatusEffect<ParalysisEffect>
{
    public MoveThunderWave()
        : base("Thunder Wave",
               MoveClass.Status,
               null, 90, // Pow & Acc
               20, 0, // PP & Priority
               TypeElectric.Singleton) { }
}