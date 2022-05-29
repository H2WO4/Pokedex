using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveSteamroller : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveSteamroller()
        : base("Steamroller",
               MoveClass.Physical,
               65, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeBug.Singleton) { }
}