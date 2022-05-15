using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveGlare : PokeMove, IM_StatusEffect<ParalysisEffect>
{
    public MoveGlare()
        : base("Glare",
               MoveClass.Status,
               null, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }
}