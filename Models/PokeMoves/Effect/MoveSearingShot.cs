using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSearingShot : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 30;

    public MoveSearingShot()
        : base("Searing Shot",
               MoveClass.Special,
               100, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypeFire.Singleton) { }
}