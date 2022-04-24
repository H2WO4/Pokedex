using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveSlam : PokeMove
{
    public MoveSlam()
        : base("Slam",
               MoveClass.Physical,
               80, 75, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}