using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveShatteredPsychePhysical : PokeMove
{
    public MoveShatteredPsychePhysical()
        : base("Shattered Psyche  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypePsychic.Singleton) { }
}