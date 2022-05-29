using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MovePoisonTail : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 10;

    public MovePoisonTail()
        : base("Poison Tail",
               MoveClass.Physical,
               50, 100, // Pow & Acc
               25, 0, // PP & Priority
               TypePoison.Singleton) { }
}