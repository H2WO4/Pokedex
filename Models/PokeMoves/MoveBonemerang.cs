using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBonemerang : PokeMove
{
    public MoveBonemerang()
        : base("Bonemerang",
               MoveClass.Physical,
               50, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeGround.Singleton) { }
}