using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MovePrecipiceBlades : PokeMove
{
    public MovePrecipiceBlades()
        : base("Precipice Blades",
               MoveClass.Physical,
               120, 85, // Pow & Acc
               10, 0, // PP & Priority
               TypeGround.Singleton) { }
}