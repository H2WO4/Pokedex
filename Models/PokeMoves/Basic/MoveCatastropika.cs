using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveCatastropika : PokeMove
{
    public MoveCatastropika()
        : base("Catastropika",
               MoveClass.Physical,
               210, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeElectric.Singleton) { }
}