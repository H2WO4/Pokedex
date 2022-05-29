using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBrutalSwing : PokeMove
{
    public MoveBrutalSwing()
        : base("Brutal Swing",
               MoveClass.Physical,
               60, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeDark.Singleton) { }
}