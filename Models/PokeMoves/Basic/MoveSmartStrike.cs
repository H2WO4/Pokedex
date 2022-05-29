using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSmartStrike : PokeMove
{
    public MoveSmartStrike()
        : base("Smart Strike",
               MoveClass.Physical,
               70, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeSteel.Singleton) { }
}