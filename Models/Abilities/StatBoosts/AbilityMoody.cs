using Pokedex.Enums;

namespace Pokedex.Models.Abilities;

public class AbilityMoody : Models.Ability
{
	#region Constructors
	public AbilityMoody()
		: base("Moody")
	{ }
	#endregion

	#region Methods
	public override void OnTurnStart()
	{
		Announce();
		Stat[] stats = { Stat.Atk, Stat.Def, Stat.SpAtk, Stat.SpDef, Stat.Spd };

		var plusStat = stats
			.Where(stat => Origin.StatBoosts[stat] != +6)
			.OrderBy(_ => Program.Rnd.Next())
			.First();
		var minusStat = stats
			.Where(stat => Origin.StatBoosts[stat] != -6)
			.Where(stat => stat != plusStat)
			.OrderBy(_ => Program.Rnd.Next())
			.First();
			
		if (plusStat != 0)
			Origin.ChangeStatBonus(plusStat, +2);
		if (minusStat != 0)
			Origin.ChangeStatBonus(minusStat, -1);
	}
	#endregion
}