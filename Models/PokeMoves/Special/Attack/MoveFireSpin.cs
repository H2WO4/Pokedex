using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFireSpin : PokeMove
{
    public MoveFireSpin()
        : base("Fire Spin",
               MoveClass.Special,
               35, 85, // Pow & Acc
               15, 0, // PP & Priority
               TypeFire.Singleton) { }
}