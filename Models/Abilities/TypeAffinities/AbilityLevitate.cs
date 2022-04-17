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
    public override bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler caster)
    {
        if (dmgInfo.Type == TypeGround.Singleton)
        {
            Announce();
            return true;
        }

        return false;
    }
    #endregion
}