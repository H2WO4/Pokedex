using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities;

public class AbilityRoughSkin : Models.Ability
{
	#region Constructors
	public AbilityRoughSkin(Pokemon origin)
		: base("Rough Skin", origin)
	{ }
	#endregion

	#region Methods

	public override void AfterReceiveDamage(DamageInfo dmgInfo, I_Battler caster)
	{
		if (!dmgInfo.Contact) return;
		
		Announce();
		DamageHandler.DoDamage(new DamageInfo(DamageClass.Percent, 16), Origin, caster);
	}
	#endregion
}