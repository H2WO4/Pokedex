using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveConversion : PokeMove
{
    public MoveConversion()
        : base("Conversion",
               MoveClass.Status,
               null, null, // Pow & Acc
               30, 0, // PP & Priority
               TypeNormal.Singleton) { }
}