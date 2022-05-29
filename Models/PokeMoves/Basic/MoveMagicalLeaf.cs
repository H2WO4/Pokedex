using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveMagicalLeaf : PokeMove
{
    public MoveMagicalLeaf()
        : base("Magical Leaf",
               MoveClass.Special,
               60, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeGrass.Singleton) { }
}