using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.PokemonMoves;

public class MoveFinalGambit : PokeMove
{
    public MoveFinalGambit()
        : base("Final Gambit",
               MoveClass.Special,
               null, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypeFighting.Singleton) { }

    protected override void DoAction(I_Battler target)
    {
        var damage = Caster.CurrHP;
        DamageHandler.DoDamage(new DamageInfo(DamageClass.Pure, damage, Type), Caster, target);
        Caster.DoKO();
    }
}