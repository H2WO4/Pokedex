using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveOceanicOperetta : PokeMove
{
    public MoveOceanicOperetta()
        : base("Oceanic Operetta",
               MoveClass.Special,
               195, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeWater.Singleton) { }
}