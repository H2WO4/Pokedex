using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveToxic : PokeMove, IM_StatusEffect<PoisonEffect>
{
    public MoveToxic()
        : base("Toxic",
               MoveClass.Status,
               null, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypePoison.Singleton) { }
}