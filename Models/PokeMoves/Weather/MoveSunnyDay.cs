using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.Weathers;


namespace Pokedex.Models.PokeMoves;

public class MoveSunnyDay : PokeMove, IM_Weather<WeatherZenith>
{
    public MoveSunnyDay()
        : base("Sunny Day",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeRock.Singleton) { }
}