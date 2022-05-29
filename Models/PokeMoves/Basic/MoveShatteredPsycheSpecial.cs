using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveShatteredPsycheSpecial : PokeMove
{
    public MoveShatteredPsycheSpecial()
        : base("Shattered Psyche  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypePsychic.Singleton) { }
}