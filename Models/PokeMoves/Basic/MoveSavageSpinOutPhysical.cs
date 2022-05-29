using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSavageSpinOutPhysical : PokeMove
{
    public MoveSavageSpinOutPhysical()
        : base("Savage Spin Out  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeBug.Singleton) { }
}