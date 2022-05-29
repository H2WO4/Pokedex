using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBloomDoomSpecial : PokeMove
{
    public MoveBloomDoomSpecial()
        : base("Bloom Doom  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeGrass.Singleton) { }
}