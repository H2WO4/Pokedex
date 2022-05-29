using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveFinalGambit : PokeMove, I_Skill
{
    public MoveFinalGambit()
        : base("Final Gambit",
               MoveClass.Special,
               null, 100, // Pow & Acc
               5, 0, // PP & Priority
               TypeFighting.Singleton) { }

    void I_Skill.DoAction(I_Battler target)
    {
        int damage = Caster.CurrHP;
        InteractionHandler.DoDamage(new DamageInfo(CalcClass.Pure, damage), Caster, target);
        Caster.DoKO();
    }
}