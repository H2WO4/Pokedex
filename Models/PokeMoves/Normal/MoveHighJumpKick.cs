using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveHighJumpKick : PokeMove, I_Skill
{
    public MoveHighJumpKick()
        : base("High Jump Kick",
               MoveClass.Physical,
               130, 90, // Pow & Acc
               10, 0, // PP & Priority
               TypeFighting.Singleton) { }

    public void OnMiss(I_Battler target)
        => InteractionHandler.DoDamageNoCaster(new DamageInfo(CalcClass.Percent, 50), Caster);
}