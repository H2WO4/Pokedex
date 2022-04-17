namespace Pokedex.Models.Abilities;

public class AbilityCloudNine : Models.Ability
{
    #region Constructors
    public AbilityCloudNine(Pokemon origin)
        : base("CloudNine", origin) { }
    #endregion

    #region Methods
    public override bool AllowWeather()
        => false;
    #endregion
}