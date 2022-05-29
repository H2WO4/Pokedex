using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDragonHammer : PokeMove
{
    public MoveDragonHammer()
        : base("Dragon Hammer",
               MoveClass.Physical,
               90, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeDragon.Singleton) { }
}