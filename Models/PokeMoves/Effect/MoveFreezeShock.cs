using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveFreezeShock : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 30;

    public MoveFreezeShock()
        : base("Freeze Shock",
               MoveClass.Physical,
               140, 90, // Pow & Acc
               5, 0, // PP & Priority
               TypeIce.Singleton) { }
}