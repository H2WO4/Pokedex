using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveExplosion : PokeMove
{
    public MoveExplosion()
        : base("Explosion",
               MoveClass.Physical,
               250, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypeNormal.Singleton) { }
}