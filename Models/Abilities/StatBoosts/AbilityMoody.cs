using Pokedex.Enums;

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
			Stat[] stats = { Stat.Atk, Stat.Def, Stat.SpAtk, Stat.SpDef, Stat.Spd };

			var plusStat = stats
				.Where(stat => this.Origin.StatBoosts[stat] != +6)
				.OrderBy(stat => Program.rnd.Next())
				.First();
			var minusStat = stats
				.Where(stat => this.Origin.StatBoosts[stat] != -6)
				.Where(stat => stat != plusStat)
				.OrderBy(stat => Program.rnd.Next())
				.First();
			
			if (plusStat != Stat.None)
				this.Origin.ChangeStatBonus(plusStat, +2);
			if (minusStat != Stat.None)
				this.Origin.ChangeStatBonus(minusStat, -1);
		}
		#endregion
	}
}