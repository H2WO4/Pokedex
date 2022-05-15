using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveLovelyKiss : PokeMove, IM_StatusEffect<SleepEffect>
{
    public MoveLovelyKiss()
        : base("Lovely Kiss",
               MoveClass.Status,
               null, 75, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}