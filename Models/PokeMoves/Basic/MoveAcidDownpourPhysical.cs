using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAcidDownpourPhysical : PokeMove
{
    public MoveAcidDownpourPhysical()
        : base("Acid Downpour  Physical",
               MoveClass.Physical,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypePoison.Singleton) { }
}