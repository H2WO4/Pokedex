using Pokedex.Enums;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveAuraSphere : PokeMove
{
    public MoveAuraSphere()
        : base("Aura Sphere",
               MoveClass.Special,
               80, null, // Pow & Acc
               20, 0, // PP & Priority
               TypeFighting.Singleton) { }
}