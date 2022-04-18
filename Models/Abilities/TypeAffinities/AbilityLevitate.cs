using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Abilities;

public class AbilityLevitate : Models.Ability
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