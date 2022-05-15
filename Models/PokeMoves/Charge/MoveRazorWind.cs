using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveRazorWind : PokeMove
{
    public MoveRazorWind()
        : base("Razor Wind",
               MoveClass.Special,
               80, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}