using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSpikeCannon : PokeMove, IM_MultiHit
{
    public MoveSpikeCannon()
        : base("Spike Cannon",
               MoveClass.Physical,
               20, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}