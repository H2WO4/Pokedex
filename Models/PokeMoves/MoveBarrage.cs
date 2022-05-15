using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveBarrage : PokeMove
{
    public MoveBarrage()
        : base("Barrage",
               MoveClass.Physical,
               15, 85, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}