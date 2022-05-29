using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveVacuumWave : PokeMove
{
    public MoveVacuumWave()
        : base("Vacuum Wave",
               MoveClass.Special,
               40, 100, // Pow & Acc
               30, 1, // PP & Priority
               TypeFighting.Singleton) { }
}