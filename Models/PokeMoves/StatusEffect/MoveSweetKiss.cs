using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSweetKiss : PokeMove, IM_StatusEffect<ConfusionEffect>
{
    public MoveSweetKiss()
        : base("Sweet Kiss",
               MoveClass.Status,
               null, 75, // Pow & Acc
               10, 0, // PP & Priority
               TypeFairy.Singleton) { }
}