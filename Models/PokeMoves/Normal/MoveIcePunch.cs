using Pokedex.Enums;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveIcePunch : PokeMove
{
    public MoveIcePunch()
        : base("Ice-Punch",
               MoveClass.Physical,
               75, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeIce.Singleton) { }
}