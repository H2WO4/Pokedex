using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBlackHoleEclipseSpecial : PokeMove
{
    public MoveBlackHoleEclipseSpecial()
        : base("Black Hole Eclipse  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeDark.Singleton) { }
}