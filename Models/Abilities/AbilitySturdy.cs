using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities
{
	public class AbilitySturdy : Ability
	{
		#region Variables
		private bool _isFullHP;
		#endregion

		#region Constructors
		public AbilitySturdy()
			: base("Sturdy")
		{ }
		#endregion

		#region Methods
		public override void BeforeDefend(I_PokeMove move)
			=> this._isFullHP = this.Origin.CurrHP == this.Origin.HP();

		public override bool OnKilled(I_Battler killer)
		{
			if (this._isFullHP)
			{
				this.Origin.CurrHP = 1;
				this.Announce();
				Console.WriteLine($"But {this.Origin.Name} endured the hit!");
				return true;
			}
			return false;
		}
		#endregion
	}
}