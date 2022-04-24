namespace Pokedex.Models.Abilities;

public class AbilityAirLock : Ability
{
    #region Constructors
    public AbilityAirLock(Pokemon origin)
        : base("Air Lock", origin) { }
    #endregion

    #region Properties - Conditions
    public override bool AllowWeather
        => false;
    #endregion
}