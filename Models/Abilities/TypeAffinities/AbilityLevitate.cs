using Pokedex.Interfaces;
using Pokedex.Models.PokeTypes;

namespace Pokedex.Models.Abilities;

public class AbilityLevitate : Ability
{
    #region Constructors
    public AbilityLevitate(Pokemon origin)
        : base("Levitate", origin) { }
    #endregion

    #region Methods
    public override bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler? caster = null)
    {
        if (dmgInfo.Type != TypeGround.Singleton)
            return false;
        
        Announce();
        return true;

    }
    #endregion
}