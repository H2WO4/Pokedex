using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveIcicleSpear : PokeMove, IM_MultiHit
{
    public MoveIcicleSpear()
        : base("Icicle Spear",
               MoveClass.Physical,
               25, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeIce.Singleton) { }
}