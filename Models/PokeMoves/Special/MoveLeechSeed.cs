using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLeechSeed : PokeMove
{
    public MoveLeechSeed()
        : base("Leech Seed",
               MoveClass.Status,
               null, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeGrass.Singleton) { }
}