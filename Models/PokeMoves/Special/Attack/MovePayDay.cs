using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePayDay : PokeMove
{
    public MovePayDay()
        : base("Pay Day",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}