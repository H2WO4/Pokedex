using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSavageSpinOutSpecial : PokeMove
{
    public MoveSavageSpinOutSpecial()
        : base("Savage Spin Out  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeBug.Singleton) { }
}