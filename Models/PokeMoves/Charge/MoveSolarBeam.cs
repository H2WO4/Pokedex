using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSolarBeam : PokeMove
{
    public MoveSolarBeam()
        : base("Solar Beam",
               MoveClass.Special,
               120, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeGrass.Singleton) { }
}