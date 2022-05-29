using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDragonClaw : PokeMove
{
    public MoveDragonClaw()
        : base("Dragon Claw",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeDragon.Singleton) { }
}