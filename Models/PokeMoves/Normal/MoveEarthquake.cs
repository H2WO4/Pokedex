using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveEarthquake : PokeMove
{
    public MoveEarthquake()
        : base("Earthquake",
               MoveClass.Physical,
               100, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeGround.Singleton) { }
}