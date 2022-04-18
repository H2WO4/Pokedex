using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities;

public class AbilitySturdy : Models.Ability
{
    #region Constructors
    public AbilitySturdy(Pokemon origin)
        : base("Sturdy", origin) { }
    #endregion

    #region Methods
    public override int OnKilled(I_Battler? killer = null)
    {
        if (killer is null)
            return 0;
        
        if (Origin.CurrHP != Origin.HP())
            return 0;
        
        Announce();
        Console.WriteLine($"But {Origin} endured the hit!");
        return 1;

    }
    #endregion
}