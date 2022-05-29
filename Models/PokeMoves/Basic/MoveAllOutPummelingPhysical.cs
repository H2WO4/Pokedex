using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAllOutPummelingPhysical : PokeMove
{
    public MoveAllOutPummelingPhysical()
        : base("All Out Pummeling  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeFighting.Singleton) { }
}