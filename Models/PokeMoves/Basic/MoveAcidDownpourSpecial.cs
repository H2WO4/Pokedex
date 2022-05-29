using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAcidDownpourSpecial : PokeMove
{
    public MoveAcidDownpourSpecial()
        : base("Acid Downpour  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypePoison.Singleton) { }
}