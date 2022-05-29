using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePsychoCut : PokeMove
{
    public MovePsychoCut()
        : base("Psycho Cut",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypePsychic.Singleton) { }
}