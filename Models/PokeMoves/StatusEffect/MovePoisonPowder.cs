using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MovePoisonPowder : PokeMove, IM_StatusEffect<PoisonEffect>
{
    public MovePoisonPowder()
        : base("Poison Powder",
               MoveClass.Status,
               null, 75, // Pow & Acc
               35, 0, // PP & Priority
               TypePoison.Singleton) { }
}