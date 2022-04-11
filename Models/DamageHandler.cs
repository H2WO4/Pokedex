using Pokedex.Interfaces;
using Pokedex.Enums;
using Pokedex.Utils;

namespace Pokedex.Models
{
	public class DamageHandler
	{
		#region Constructors
		private DamageHandler() { }
		#endregion

		#region Methods
		public static bool DoDamage(DamageInfo dmgInfo, I_Battler caster, I_Battler target)
		{
			if (caster.CurrHP == 0 || target.CurrHP == 0)
				return false;

			// Activate abilites and cancel the damage if necessary
			bool cancel = false;
			if (caster != target)
			{
				cancel |= caster.Ability?.OnInflictDamage(dmgInfo, target) ?? false;
				cancel |= target.Ability?.OnReceiveDamage(dmgInfo, caster) ?? false;
			}
			else
			{
				cancel |= caster.Ability?.OnSelfDamage(dmgInfo) ?? false;
			}
			if (cancel) return false;

			double damage;
			switch (dmgInfo)
			{
				case { Class: DamageClass.Pure }:
					// Calculate the damge
					damage = dmgInfo.Power;
				break;

				case { Class: DamageClass.Percent }:
					// Calculate the damage
					damage = target.HP() * dmgInfo.Power / 100d;
				break;

				case { Class: DamageClass.Calculated, Type: PokeType type }:
					// Initial damage
					damage = (0.4 * caster.Level + 2) * (dmgInfo.Power);

					// Find which stat to use
					IEnumerable<Stat> atkStats = dmgInfo.AttackStats.GetFlags();
					IEnumerable<Stat> defStats = dmgInfo.DefenseStats.GetFlags();
					// Adjust for stats
					double multipler = 1;
					multipler *= atkStats
						.Select(stat => caster.GetStat(stat))
						.Average();
					multipler /= defStats
						.Select(stat => target.GetStat(stat))
						.Average();
					damage *= multipler;

					// Continue the calculation
					damage = damage / 50 + 2;

					// Apply weather
					damage = target.Arena.Weather.OnDamageGive(damage, type);

					// Apply type weaknesses
					damage *= target.GetAffinity(type);
				break;

				default: throw new ArgumentException();
			}

			if (damage >= target.CurrHP)
			{
				int postDeathDamage = target.Ability?.OnKilled(caster) ?? 0;
				damage -= postDeathDamage;
			}

			// Announce the damage
			int percentage = Math.Clamp((int)damage * 100 / target.HP(), 0, 100);
			Console.WriteLine($"{target.Name} lost {percentage}% HP");

			// Apply the damage
			target.CurrHP -= (int)damage;

			// Indicate that everything went smoothly
			return true;
		}
		#endregion
	}
}