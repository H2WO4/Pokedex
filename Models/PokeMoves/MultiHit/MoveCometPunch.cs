using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveCometPunch : PokeMove, I_MultiHit
{
    public MoveCometPunch()
        : base("Comet Punch",
               MoveClass.Physical,
               18, 85, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}