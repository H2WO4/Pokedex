using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities
{
	public class AbilityWonderGuard : Models.Ability
	{
		#region Constructors
		public AbilityWonderGuard()
			: base("Wonder Guard")
		{ }
		#endregion

		#region Methods
		public override bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler caster)
		{
			if (dmgInfo.Type?.CalculateAffinity(Origin.Types) <= 1)
			{
				Announce();
				return true;
			}
			
			return false;
		}
		#endregion
	}
}