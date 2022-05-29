using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveTectonicRageSpecial : PokeMove
{
    public MoveTectonicRageSpecial()
        : base("Tectonic Rage  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeGround.Singleton) { }
}