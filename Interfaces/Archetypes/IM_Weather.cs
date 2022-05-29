using System.Reflection;
using Pokedex.Models;

namespace Pokedex.Interfaces.Archetypes;

public interface IM_Weather<TWeather> : I_Skill
    where TWeather : Weather
{
    void I_Skill.DoAction(I_Battler target)
    {
        Type          type = typeof(TWeather);
        PropertyInfo? prop = type.GetRuntimeProperty("Singleton");
        object?       val  = prop!.GetValue(null);
        
        Caster.Arena.Weather = (Weather) val!;
    }
}