using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePowerWhip : PokeMove
{
    public MovePowerWhip()
        : base("Power Whip",
               MoveClass.Physical,
               120, 85, // Pow & Acc
               10, 0, // PP & Priority
               TypeGrass.Singleton) { }
}