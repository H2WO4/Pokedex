using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities
{
	public class AbilityMoody : Ability
	{
		#region Constructors
		public AbilityMoody()
			: base("Moody")
		{ }
		#endregion

		#region Methods
		public override void OnTurnStart()
		{
			this.Announce();
			string[] stats = { "atk", "def", "spAtk", "spDef", "spd" };

			var plusStat = stats
				.Where(stat => this.Origin.StatBoosts[stat] != +6)
				.OrderBy(stat => Program.rnd.Next())
				.First();
			var minusStat = stats
				.Where(stat => this.Origin.StatBoosts[stat] != -6)
				.Where(stat => stat != plusStat)
				.OrderBy(stat => Program.rnd.Next())
				.First();
			
			if (plusStat != null)
				this.Origin.ChangeStatBonus(plusStat, +2);
			if (minusStat != null)
				this.Origin.ChangeStatBonus(minusStat, -1);
		}
		#endregion
	}
}