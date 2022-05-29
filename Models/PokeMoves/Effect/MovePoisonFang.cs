using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MovePoisonFang : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 50;

    public MovePoisonFang()
        : base("Poison Fang",
               MoveClass.Physical,
               50, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypePoison.Singleton) { }
}