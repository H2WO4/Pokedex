using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveInfernoOverdriveSpecial : PokeMove
{
    public MoveInfernoOverdriveSpecial()
        : base("Inferno Overdrive  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeFire.Singleton) { }
}