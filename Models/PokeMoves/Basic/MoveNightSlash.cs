using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveNightSlash : PokeMove
{
    public MoveNightSlash()
        : base("Night Slash",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeDark.Singleton) { }
}