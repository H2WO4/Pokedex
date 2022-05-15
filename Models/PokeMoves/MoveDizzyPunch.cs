using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveDizzyPunch : PokeMove
{
    public MoveDizzyPunch()
        : base("Dizzy Punch",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}