using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveLeafBlade : PokeMove
{
    public MoveLeafBlade()
        : base("Leaf Blade",
               MoveClass.Physical,
               90, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGrass.Singleton) { }
}