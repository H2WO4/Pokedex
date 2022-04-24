using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;

namespace Pokedex.Models.PokeMoves;

public class MoveHeadbutt : PokeMove, I_Effect<FlinchEffect>
{
    public int EffectChance
        => 30;
    
    public MoveHeadbutt()
        : base("Headbutt",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}