using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveFlareBlitz : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 10;

    public MoveFlareBlitz()
        : base("Flare Blitz",
               MoveClass.Physical,
               120, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeFire.Singleton) { }
}