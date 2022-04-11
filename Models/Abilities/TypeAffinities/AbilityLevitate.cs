using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Abilities
{
	public class AbilityLevitate : Ability
	{
		#region Constructors
		public AbilityLevitate()
			: base("Levitate")
		{ }
		#endregion

		#region Methods
		public override bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler caster)
		{
			if (dmgInfo.Type == TypeGround.Singleton)
			{
				this.Announce();
				return true;
			}
			return false;
		}
		#endregion
	}
}