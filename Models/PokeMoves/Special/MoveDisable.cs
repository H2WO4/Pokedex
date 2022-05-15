using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDisable : PokeMove
{
    public MoveDisable()
        : base("Disable",
               MoveClass.Status,
               null, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}