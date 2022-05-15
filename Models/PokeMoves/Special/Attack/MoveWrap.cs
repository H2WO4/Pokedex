using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveWrap : PokeMove
{
    public MoveWrap()
        : base("Wrap",
               MoveClass.Physical,
               15, 90, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}