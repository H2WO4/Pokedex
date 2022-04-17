using Pokedex.Enums;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves;

public class MoveExtremeSpeed : PokeMove
{
    public MoveExtremeSpeed()
        : base("Extreme Speed",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               5, 2, // PP & Priority
               TypeNormal.Singleton) { }
}