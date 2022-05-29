using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveStrength : PokeMove
{
    public MoveStrength()
        : base("Strength",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}