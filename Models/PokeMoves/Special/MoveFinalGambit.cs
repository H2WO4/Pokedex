using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.PokeMoves;

public class MoveFinalGambit : PokeMove
{
    public MoveFinalGambit()
        : base("Final Gambit",
               MoveClass.Special,
               null, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypeFighting.Singleton) { }

    public override void DoAction(I_Battler target)
    {
        int damage = Caster.CurrHP;
        DamageHandler.DoDamage(new DamageInfo(DamageClass.Pure, damage), Caster, target);
        Caster.DoKO();
    }
}