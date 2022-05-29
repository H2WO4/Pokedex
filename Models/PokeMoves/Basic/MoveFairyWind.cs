using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFairyWind : PokeMove
{
    public MoveFairyWind()
        : base("Fairy Wind",
               MoveClass.Special,
               40, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeFairy.Singleton) { }
}