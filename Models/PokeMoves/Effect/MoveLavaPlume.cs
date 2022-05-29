using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveLavaPlume : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 30;

    public MoveLavaPlume()
        : base("Lava Plume",
               MoveClass.Special,
               80, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeFire.Singleton) { }
}