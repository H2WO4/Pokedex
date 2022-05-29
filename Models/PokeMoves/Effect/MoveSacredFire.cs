using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSacredFire : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 50;

    public MoveSacredFire()
        : base("Sacred Fire",
               MoveClass.Physical,
               100, 95, // Pow & Acc
               5, 0, // PP & Priority
               TypeFire.Singleton) { }
}