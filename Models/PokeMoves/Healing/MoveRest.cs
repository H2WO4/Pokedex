using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveRest : PokeMove, I_Self
{
    public MoveRest()
        : base("Rest",
               MoveClass.Status,
               null, null, // Pow & Acc
               10, 0, // PP & Priority
               TypePsychic.Singleton) { }

    void I_Skill.DoAction(I_Battler target)
    {
        bool success = SleepEffect.Apply(target, 2);
        if (!success)
        {
            Console.WriteLine("But it failed!");
            return;
        }

        InteractionHandler.DoHealing(new HealingInfo(CalcClass.Percent, 100), target);

        target.StatusEffects.RemoveAll(status => status.IsDebuff);
    }
}