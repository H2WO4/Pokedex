using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSing : PokeMove, IM_StatusEffect<SleepEffect>
{
    public MoveSing()
        : base("Sing",
               MoveClass.Status,
               null, 55, // Pow & Acc
               15, 0, // PP & Priority
               TypeNormal.Singleton) { }
}