using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLeafage : PokeMove
{
    public MoveLeafage()
        : base("Leafage",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               40, 0, // PP & Priority
               TypeGrass.Singleton) { }
}