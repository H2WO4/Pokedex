using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveShockWave : PokeMove
{
    public MoveShockWave()
        : base("Shock Wave",
               MoveClass.Special,
               60, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeElectric.Singleton) { }
}