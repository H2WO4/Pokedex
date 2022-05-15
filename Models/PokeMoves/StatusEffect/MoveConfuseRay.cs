using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveConfuseRay : PokeMove, IM_StatusEffect<ConfusionEffect>
{
    public MoveConfuseRay()
        : base("Confuse Ray",
               MoveClass.Status,
               null, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeGhost.Singleton) { }
}