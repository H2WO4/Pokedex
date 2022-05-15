using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveThunderPunch : PokeMove
{
    public MoveThunderPunch()
        : base("Thunder-Punch",
               MoveClass.Physical,
               75, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeElectric.Singleton) { }
}