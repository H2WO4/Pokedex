using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSubstitute : PokeMove
{
    public MoveSubstitute()
        : base("Substitute",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}