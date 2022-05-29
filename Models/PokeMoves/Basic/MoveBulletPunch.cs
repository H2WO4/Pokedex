using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBulletPunch : PokeMove
{
    public MoveBulletPunch()
        : base("Bullet Punch",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               30, 1, // PP & Priority
               TypeSteel.Singleton) { }
}