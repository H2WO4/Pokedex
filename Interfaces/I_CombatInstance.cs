using Pokedex.Models;

namespace Pokedex.Interfaces
{
	public interface I_CombatInstance
	{
		# region Properties
		// Teams
		
		public Player PlayerA { get; }
		public Player PlayerB { get; }

		// Terrain Effects
		public Weather Weather { get; set; }
		# endregion

		# region Methods
		public bool DoTurn();
		# endregion
	}
}