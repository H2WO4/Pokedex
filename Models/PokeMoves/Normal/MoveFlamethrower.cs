using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveFlamethrower : PokeMove, I_EffectChance<BurnEffect>
{
    public int EffectChance
        => 10;

    public MoveFlamethrower()
        : base("Flamethrower",
               MoveClass.Special,
               90, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeFire.Singleton) { }
}