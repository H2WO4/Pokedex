using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveDragonBreath : PokeMove, IM_StatusEffectBonus<ParalysisEffect>
{
    public int EffectChance
        => 30;

    public MoveDragonBreath()
        : base("Dragon Breath",
               MoveClass.Special,
               60, 100, // Pow & Acc
               20, 0, // PP & Priority
               TypeDragon.Singleton) { }
}