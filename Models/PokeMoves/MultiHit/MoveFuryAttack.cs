using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveFuryAttack : PokeMove, I_MultiHit
{
    public MoveFuryAttack()
        : base("Fury Attack",
               MoveClass.Physical,
               15, 85, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}