using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePound : PokeMove
{
    public MovePound()
        : base("Pound",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               35, 0, // PP & Priority
               TypeNormal.Singleton) { }
}