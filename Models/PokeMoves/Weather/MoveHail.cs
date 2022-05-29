using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.Weathers;


namespace Pokedex.Models.PokeMoves;

public class MoveHail : PokeMove, IM_Weather<WeatherHail>
{
    public MoveHail()
        : base("Hail",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypeRock.Singleton) { }
}