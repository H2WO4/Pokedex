using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveWaterGun : PokeMove
{
    public MoveWaterGun()
        : base("Water Gun",
               MoveClass.Special,
               40, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypeWater.Singleton) { }
}