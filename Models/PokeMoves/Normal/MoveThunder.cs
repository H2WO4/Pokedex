using Pokedex.Enums;
using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;
using Pokedex.Models.Weathers;


namespace Pokedex.Models.PokeMoves;

public class MoveThunder : PokeMove, I_Skill
{
    public MoveThunder()
        : base("Thunder",
               MoveClass.Special,
               110, 70, // Pow & Acc
               10, 0, // PP & Priority
               TypeElectric.Singleton) { }

    bool I_Skill.AccuracyCheck(I_Battler target)
    {
        if (Arena.Weather == WeatherRain.Singleton
         || Arena.Weather == WeatherThunderstorm.Singleton)
            return true;


        return I_Skill.AccuracyCheck(this, target);
    }
}