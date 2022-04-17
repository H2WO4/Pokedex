namespace Pokedex.Models.Abilities;

public class AbilityAirLock : Models.Ability
{
    #region Constructors
    public AbilityAirLock(Pokemon origin)
        : base("Air Lock", origin) { }
    #endregion

    #region Methods
    public override bool AllowWeather()
        => false;
    #endregion
}