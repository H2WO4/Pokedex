using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveJumpKick : PokeMove
{
    public MoveJumpKick()
        : base("Jump Kick",
               MoveClass.Physical,
               100, 95, // Pow & Acc
               10, 0, // PP & Priority
               TypeFighting.Singleton) { }

    public override void OnMiss(I_Battler target)
    {
        base.OnMiss(target);
        DamageHandler.DoDamageNoCaster(new DamageInfo(DamageClass.Percent, 50), Caster);
    }
}