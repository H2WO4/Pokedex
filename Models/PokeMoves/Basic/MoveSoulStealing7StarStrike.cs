using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSoulStealing7StarStrike : PokeMove
{
    public MoveSoulStealing7StarStrike()
        : base("Soul Stealing 7 Star Strike",
               MoveClass.Physical,
               195, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeGhost.Singleton) { }
}