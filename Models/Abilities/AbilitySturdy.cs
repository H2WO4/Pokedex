using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities
{
	public class AbilitySturdy : Ability
	{
		#region Constructors
		public AbilitySturdy()
			: base("Sturdy")
		{ }
		#endregion

		#region Methods
		public override int OnKilled(I_Battler killer)
		{
			if (this.Origin.CurrHP == this.Origin.HP())
			{
				this.Announce();
				Console.WriteLine($"But {this.Origin.Name} endured the hit!");
				return 1;
			}
			return 0;
		}
		#endregion
	}
}