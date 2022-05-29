using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MovePoisonJab : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 30;

    public MovePoisonJab()
        : base("Poison Jab",
               MoveClass.Physical,
               80, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypePoison.Singleton) { }
}