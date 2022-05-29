using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBoneRush : PokeMove, IM_MultiHit
{
    public MoveBoneRush()
        : base("Bone Rush",
               MoveClass.Physical,
               25, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeGround.Singleton) { }
}