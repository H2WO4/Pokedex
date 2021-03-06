using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSwift : PokeMove
{
    public MoveSwift()
        : base("Swift",
               MoveClass.Special,
               60, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}