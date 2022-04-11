using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities
{
	public class AbilityRoughSkin : Ability
	{
		#region Constructors
		public AbilityRoughSkin()
			: base("Rough Skin")
		{ }
		#endregion

		#region Methods

		public override void AfterReceiveDamage(DamageInfo dmgInfo, I_Battler caster)
		{
			if (dmgInfo.Contact)
			{
				this.Announce();
				var damage = new DamageInfo(DamageClass.Percent, 100 / 16);
			}
		}
		#endregion
	}
}