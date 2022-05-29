using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.Weathers;


namespace Pokedex.Models.PokeMoves;

public class MoveRainDance : PokeMove, IM_Weather<WeatherRain>
{
    public MoveRainDance()
        : base("Rain Dance",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeRock.Singleton) { }
}