using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities;

public class AbilitySturdy : Models.Ability
{
    #region Constructors
    public AbilitySturdy(Pokemon origin)
        : base("Sturdy", origin) { }
    #endregion

    #region Methods
    public override int OnKilled(I_Battler killer)
    {
        if (Origin.CurrHP == Origin.HP())
        {
            Announce();
            Console.WriteLine($"But {Origin.Name} endured the hit!");
            return 1;
        }

        return 0;
    }
    #endregion
}