using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveGust : PokeMove
{
    public MoveGust()
        : base("Gust",
               MoveClass.Special,
               40, 100, // Pow & Acc
               35, 0, // PP & Priority
               TypeFlying.Singleton) { }
}