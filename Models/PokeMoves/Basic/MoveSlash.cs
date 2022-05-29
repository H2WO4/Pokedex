using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSlash : PokeMove
{
    public MoveSlash()
        : base("Slash",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}