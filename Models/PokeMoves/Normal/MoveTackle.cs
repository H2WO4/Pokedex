using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTackle : PokeMove
{
    public MoveTackle()
        : base("Tackle",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               35, 0, // PP & Priority
               TypeNormal.Singleton) { }
}