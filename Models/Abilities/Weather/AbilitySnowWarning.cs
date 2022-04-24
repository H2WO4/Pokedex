using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities;

public class AbilitySnowWarning : Ability
{
    #region Constructors
    public AbilitySnowWarning(Pokemon origin)
        : base("Snow Warning", origin) { }
    #endregion

    #region Methods
    public override void OnEnter()
    {
        Announce();
        Origin.Arena.Weather = WeatherHail.Singleton;
    }
    #endregion
}