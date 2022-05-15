using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLick : PokeMove
{
    public MoveLick()
        : base("Lick",
               MoveClass.Physical,
               30, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeGhost.Singleton) { }
}