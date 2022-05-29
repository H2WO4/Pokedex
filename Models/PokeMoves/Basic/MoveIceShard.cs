using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveIceShard : PokeMove
{
    public MoveIceShard()
        : base("Ice Shard",
               MoveClass.Physical,
               40, 100, // Pow & Acc
               30, 1, // PP & Priority
               TypeIce.Singleton) { }
}