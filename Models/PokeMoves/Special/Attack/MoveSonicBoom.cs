using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;


namespace Pokedex.Models.PokeMoves;

public class MoveSonicBoom : PokeMove, I_Skill
{
    public MoveSonicBoom()
        : base("Sonic Boom",
               MoveClass.Special,
               null, 90, // Pow & Acc
               20, 0, // PP & Priority
               TypeNormal.Singleton) { }

    void I_Skill.DoAction(I_Battler target)
    {
        bool success = InteractionHandler.DoDamage(new DamageInfo(CalcClass.Pure, 20), target, Caster);

        if (!success)
            Console.WriteLine("But it failed!");
    }
}