using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveClamp : PokeMove
{
    public MoveClamp()
        : base("Clamp",
               MoveClass.Physical,
               35, 85, // Pow & Acc
               15, 0, // PP & Priority
               TypeWater.Singleton) { }
}