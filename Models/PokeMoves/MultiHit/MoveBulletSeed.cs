using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBulletSeed : PokeMove, IM_MultiHit
{
    public MoveBulletSeed()
        : base("Bullet Seed",
               MoveClass.Physical,
               25, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeGrass.Singleton) { }
}