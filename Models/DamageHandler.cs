using Pokedex.Interfaces;
using Pokedex.Enums;

namespace Pokedex.Models
{
	public class DamageHandler
	{
		#region Constructors
		private DamageHandler() { }
		#endregion

		#region Methods
		public static void DoDamage(DamageInfo damage, I_Battler caster, I_Battler target)
		{
			/* switch (damage)
			{
				case {Type: InterType.DmgPure}:

					break;

				case {Type: InterType.Physical or InterType.Special}:

					break;
			} */
		}
		#endregion
	}
}