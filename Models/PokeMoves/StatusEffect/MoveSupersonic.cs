using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSupersonic : PokeMove, I_Effect<ConfusionEffect>
{
    public MoveSupersonic()
        : base("Supersonic",
               MoveClass.Status,
               null, 55, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }
}