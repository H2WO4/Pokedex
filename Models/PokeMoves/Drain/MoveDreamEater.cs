using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Interfaces.Archetypes;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.StatusEffects;


namespace Pokedex.Models.PokeMoves;

public class MoveDreamEater : PokeMove, IM_Drain
{
    public int DrainPower
        => 50;

    public MoveDreamEater()
        : base("Dream Eater",
               MoveClass.Special,
               100, 100, // Pow & Acc
               15, 0, // PP & Priority
               TypePsychic.Singleton) { }

    public void DoAction(I_Battler target)
    {
        if (target.StatusEffects.Any(effect => effect is SleepEffect) is false)
        {
            Console.WriteLine("But it failed!");
            return;
        }
        
        I_Skill.DoAction(this, target);
    }
}