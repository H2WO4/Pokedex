using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveGigavoltHavocPhysical : PokeMove
{
    public MoveGigavoltHavocPhysical()
        : base("Gigavolt Havoc  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeElectric.Singleton) { }
}