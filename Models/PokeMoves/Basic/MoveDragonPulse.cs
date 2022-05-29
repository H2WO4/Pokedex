using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDragonPulse : PokeMove
{
    public MoveDragonPulse()
        : base("Dragon Pulse",
               MoveClass.Special,
               85, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeDragon.Singleton) { }
}