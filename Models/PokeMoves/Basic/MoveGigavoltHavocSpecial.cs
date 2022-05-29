using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveGigavoltHavocSpecial : PokeMove
{
    public MoveGigavoltHavocSpecial()
        : base("Gigavolt Havoc  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeElectric.Singleton) { }
}