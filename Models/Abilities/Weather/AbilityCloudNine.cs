namespace Pokedex.Models.Abilities;

public class AbilityCloudNine : Ability
{
    #region Constructors
    public AbilityCloudNine(Pokemon origin)
        : base("CloudNine", origin) { }
    #endregion

    #region Properties - Conditions
    public override bool AllowWeather
        => false;
    #endregion
}