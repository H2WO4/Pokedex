using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTwinkleTackleSpecial : PokeMove
{
    public MoveTwinkleTackleSpecial()
        : base("Twinkle Tackle  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeFairy.Singleton) { }
}