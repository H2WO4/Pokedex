using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHyperFang : PokeMove
{
    public MoveHyperFang()
        : base("Hyper Fang",
               MoveClass.Physical,
               80, 90, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}