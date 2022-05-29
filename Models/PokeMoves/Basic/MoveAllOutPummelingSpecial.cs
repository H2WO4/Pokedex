using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAllOutPummelingSpecial : PokeMove
{
    public MoveAllOutPummelingSpecial()
        : base("All Out Pummeling  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeFighting.Singleton) { }
}