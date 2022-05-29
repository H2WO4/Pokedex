using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveLick : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 30;

    public MoveLick()
        : base("Lick",
               MoveClass.Physical,
               30, 100, // Pow & Acc
               30, 0, // PP & Priority
               TypeGhost.Singleton) { }
}