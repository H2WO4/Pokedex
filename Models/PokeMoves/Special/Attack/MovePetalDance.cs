using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePetalDance : PokeMove
{
    public MovePetalDance()
        : base("Petal Dance",
               MoveClass.Special,
               120, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeGrass.Singleton) { }
}