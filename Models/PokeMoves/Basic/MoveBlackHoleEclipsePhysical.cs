using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBlackHoleEclipsePhysical : PokeMove
{
    public MoveBlackHoleEclipsePhysical()
        : base("Black Hole Eclipse  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeDark.Singleton) { }
}