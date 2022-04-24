using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities;

public class AbilityDrougth : Ability
{
    #region Constructors
    public AbilityDrougth(Pokemon origin)
        : base("Drougth", origin) { }
    #endregion

    #region Methods
    public override void OnEnter()
    {
        Announce();
        Origin.Arena.Weather = WeatherZenith.Singleton;
    }
    #endregion
}