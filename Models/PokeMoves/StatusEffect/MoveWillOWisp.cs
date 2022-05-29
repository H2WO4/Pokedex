using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveWillOWisp : PokeMove, IM_StatusEffect<BurnEffect>
{
    public MoveWillOWisp()
        : base("Will O Wisp",
               MoveClass.Status,
               null, 85, // Pow & Acc
               15, 0, // PP & Priority
               TypeFire.Singleton) { }
}