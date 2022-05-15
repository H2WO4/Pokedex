using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLowKick : PokeMove
{
    public MoveLowKick()
        : base("Low Kick",
               MoveClass.Physical,
               null, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeFighting.Singleton) { }
}