using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHighHorsepower : PokeMove
{
    public MoveHighHorsepower()
        : base("High Horsepower",
               MoveClass.Physical,
               95, 95, // Pow & Acc
               10, 0, // PP & Priority
               TypeGround.Singleton) { }
}