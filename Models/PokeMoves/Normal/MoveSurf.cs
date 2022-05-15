using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSurf : PokeMove
{
    public MoveSurf()
        : base("Surf",
               MoveClass.Special,
               90, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeWater.Singleton) { }
}