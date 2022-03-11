using Pokedex.Models;

namespace Pokedex.Interfaces
{
	public interface I_Weather
	{
		#region Properties
		public string Name { get; }
		#endregion

		#region Methods
		public double OnDamageGive(double damage, PokeType type);

		public void OnEnter();
		public void OnExit();

		public void OnTurnStart(Combat context);
		public void OnTurnEnd(Combat context);
		#endregion
	}
}