using Pokedex.Enums;


namespace Pokedex.Models.Abilities;

public class AbilitySpeedBoost : Models.Ability
{
	#region Constructors
	public AbilitySpeedBoost(Pokemon origin)
		: base("Speed Boost", origin) { }
	#endregion

	#region Methods
	public override void OnTurnEnd()
	{
		Announce();
		Origin.ChangeStatBonus(Stat.Spd, +1);
	}
	#endregion
}