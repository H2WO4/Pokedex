using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;

namespace Pokedex.Models.PokeMoves;

public class MoveStomp : PokeMove, I_Effect<ParalysisEffect>
{
    public int EffectChance
        => 30;
    
    public MoveStomp()
        : base("Stomp",
               MoveClass.Physical,
               65, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}