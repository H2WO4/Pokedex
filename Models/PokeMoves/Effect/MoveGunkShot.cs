using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveGunkShot : PokeMove, IM_StatusEffectBonus<PoisonEffect>
{
    public int EffectChance
        => 30;

    public MoveGunkShot()
        : base("Gunk Shot",
               MoveClass.Physical,
               120, 80, // Pow & Acc
               5, 0, // PP & Priority
               TypePoison.Singleton) { }
}