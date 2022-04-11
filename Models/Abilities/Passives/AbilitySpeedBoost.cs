using Pokedex.Enums;

namespace Pokedex.Models.Abilities
{
	public class AbilitySpeedBoost : Ability
	{
		#region Constructors
		public AbilitySpeedBoost()
			: base("Speed Boost")
		{ }
		#endregion

		#region Methods
		public override void OnTurnEnd()
		{
			this.Announce();
			this.Origin.ChangeStatBonus(Stat.Spd, +1);
		}
		#endregion
	}
}