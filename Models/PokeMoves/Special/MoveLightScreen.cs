using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLightScreen : PokeMove
{
    public MoveLightScreen()
        : base("Light Screen",
               MoveClass.Status,
               null, null, // Pow & Acc
               30, 0, // PP & Priority
               TypePsychic.Singleton) { }
}