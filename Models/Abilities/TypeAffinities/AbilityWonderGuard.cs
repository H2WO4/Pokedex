using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities
{
	public class AbilityWonderGuard : Ability
	{
		#region Constructors
		public AbilityWonderGuard()
			: base("Wonder Guard")
		{ }
		#endregion

		#region Methods
		public override bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler caster)
		{
			if (dmgInfo.Type?.CalculateAffinity(this.Origin.Types) <= 1)
			{
				this.Announce();
				return true;
			}
			
			return false;
		}
		#endregion
	}
}