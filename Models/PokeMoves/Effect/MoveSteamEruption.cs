using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSteamEruption : PokeMove, IM_StatusEffectBonus<BurnEffect>
{
    public int EffectChance
        => 30;

    public MoveSteamEruption()
        : base("Steam Eruption",
               MoveClass.Special,
               110, 95, // Pow & Acc
               5, 0, // PP & Priority
               TypeWater.Singleton) { }
}