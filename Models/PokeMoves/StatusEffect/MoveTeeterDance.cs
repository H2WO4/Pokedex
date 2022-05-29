using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveTeeterDance : PokeMove, IM_StatusEffect<ConfusionEffect>
{
    public MoveTeeterDance()
        : base("Teeter Dance",
               MoveClass.Status,
               null, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}