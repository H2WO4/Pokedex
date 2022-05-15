using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveJumpKick : PokeMove, I_Skill
{
    public MoveJumpKick()
        : base("Jump Kick",
               MoveClass.Physical,
               100, 95, // Pow & Acc
               10, 0, // PP & Priority
               TypeFighting.Singleton) { }

    void I_Skill.OnMiss(I_Battler target)
    {
        (this as I_Skill).OnMiss(target);
        InteractionHandler.DoDamageNoCaster(new DamageInfo(CalcClass.Percent, 50), Caster);
    }
}