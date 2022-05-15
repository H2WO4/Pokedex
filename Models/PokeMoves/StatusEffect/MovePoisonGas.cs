using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MovePoisonGas : PokeMove, IM_StatusEffect<PoisonEffect>
{
    public MovePoisonGas()
        : base("Poison Gas",
               MoveClass.Status,
               null, 90, // Pow & Acc
               40, 0, // PP & Priority
               TypePoison.Singleton) { }
}