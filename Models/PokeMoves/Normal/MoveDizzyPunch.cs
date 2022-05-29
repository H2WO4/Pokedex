using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveDizzyPunch : PokeMove, IM_StatusEffectBonus<ConfusionEffect>
{
    public int EffectChance
        => 20;

    public MoveDizzyPunch()
        : base("Dizzy Punch",
               MoveClass.Physical,
               70, 100, // Pow & Acc
               10, 0, // PP & Priority
               TypeNormal.Singleton) { }
}