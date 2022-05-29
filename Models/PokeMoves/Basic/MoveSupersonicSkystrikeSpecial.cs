using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSupersonicSkystrikeSpecial : PokeMove
{
    public MoveSupersonicSkystrikeSpecial()
        : base("Supersonic Skystrike  Special",
               MoveClass.Special,
               null, null, // Pow & Acc
               1, 0, // PP & Priority
               TypeFlying.Singleton) { }
}