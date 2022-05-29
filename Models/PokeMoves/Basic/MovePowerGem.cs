using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePowerGem : PokeMove
{
    public MovePowerGem()
        : base("Power Gem",
               MoveClass.Special,
               80, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeRock.Singleton) { }
}