using Pokedex.Enums;


namespace Pokedex.Models.Abilities;

public class AbilitySimple : Ability
{
    #region Constructors
    public AbilitySimple(Pokemon origin)
        : base("Simple", origin) { }
    #endregion

    #region Methods
    public override int OnStatChange(Stat stat, int val)
    {
        Announce();
        return val * 2;
    }
    #endregion
}