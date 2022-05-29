using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAquaTail : PokeMove
{
    public MoveAquaTail()
        : base("Aqua Tail",
               MoveClass.Physical,
               90, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeWater.Singleton) { }
}