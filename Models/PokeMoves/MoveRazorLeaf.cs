using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveRazorLeaf : PokeMove
{
    public MoveRazorLeaf()
        : base("Razor Leaf",
               MoveClass.Physical,
               55, 95, // Pow & Acc
               25, 0, // PP & Priority
               TypeGrass.Singleton) { }
}