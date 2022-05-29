using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveDarkVoid : PokeMove, IM_StatusEffect<SleepEffect>
{
    public MoveDarkVoid()
        : base("Dark Void",
               MoveClass.Status,
               null, 50, // Pow & Acc
               10, 0, // PP & Priority
               TypeDark.Singleton) { }
}