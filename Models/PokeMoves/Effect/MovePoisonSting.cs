using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;

namespace Pokedex.Models.PokeMoves;

public class MovePoisonSting : PokeMove, I_Effect<PoisonEffect>
{
    public int EffectChance
        => 30;
    
    public MovePoisonSting()
        : base("Poison Sting",
               MoveClass.Physical,
               15, 100, // Pow & Acc
               35, 0, // PP & Priority
               TypePoison.Singleton) { }
}