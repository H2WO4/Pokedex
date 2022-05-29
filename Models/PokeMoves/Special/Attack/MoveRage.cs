using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveRage : PokeMove
{
    public MoveRage()
        : base("Rage",
               MoveClass.Physical,
               20, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}