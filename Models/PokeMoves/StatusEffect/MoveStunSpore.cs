using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveStunSpore : PokeMove, IM_StatusEffect<ParalysisEffect>
{
    public MoveStunSpore()
        : base("Stun Spore",
               MoveClass.Status,
               null, 75, // Pow & Acc
               30, 0, // PP & Priority
               TypeGrass.Singleton) { }
}