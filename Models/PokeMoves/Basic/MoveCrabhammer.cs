using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCrabhammer : PokeMove
{
    public MoveCrabhammer()
        : base("Crabhammer",
               MoveClass.Physical,
               100, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeWater.Singleton) { }
}