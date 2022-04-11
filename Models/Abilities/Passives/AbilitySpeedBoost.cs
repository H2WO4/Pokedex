using Pokedex.Enums;

namespace Pokedex.Models.Abilities
{
	public class AbilitySpeedBoost : Models.Ability
	{
		#region Constructors
		public AbilitySpeedBoost()
			: base("Speed Boost")
		{ }
		#endregion

		#region Methods
		public override void OnTurnEnd()
		{
			Announce();
			Origin.ChangeStatBonus(Stat.Spd, +1);
		}
		#endregion
	}
}