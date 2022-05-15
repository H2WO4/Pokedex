using Pokedex.Enums;


namespace Pokedex.Models.Abilities;

public class AbilityContrary : Ability
{
    #region Constructors
    public AbilityContrary(Pokemon origin)
        : base("Contrary", origin) { }
    #endregion

    #region Methods
    public override int OnStatChange(Stat stat, int val)
    {
        Announce();
        return -val;
    }
    #endregion
}