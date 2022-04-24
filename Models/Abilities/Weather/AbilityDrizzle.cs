using Pokedex.Models.Weathers;

namespace Pokedex.Models.Abilities;

public class AbilityDrizzle : Ability
{
    #region Constructors
    public AbilityDrizzle(Pokemon origin)
        : base("Drizzle", origin) { }
    #endregion

    #region Methods
    public override void OnEnter()
    {
        Announce();
        Origin.Arena.Weather = WeatherZenith.Singleton;
    }
    #endregion
}