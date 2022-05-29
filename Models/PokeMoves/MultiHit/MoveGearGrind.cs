using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveGearGrind : PokeMove, IM_DoubleHit
{
    public MoveGearGrind()
        : base("Gear Grind",
               MoveClass.Physical,
               50, 85, // Pow & Acc
               15, 0, // PP & Priority
               TypeSteel.Singleton) { }
}