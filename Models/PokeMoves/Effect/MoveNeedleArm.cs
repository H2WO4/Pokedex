using Pokedex.Enums;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveNeedleArm : PokeMove, IM_StatusEffectBonus<FlinchEffect>
{
    public int EffectChance
        => 30;

    public MoveNeedleArm()
        : base("Needle Arm",
               MoveClass.Physical,
               60, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypeGrass.Singleton) { }
}