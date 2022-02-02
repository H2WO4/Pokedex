using Pokedex.Enums;
using Pokedex.Models;

namespace Pokedex.Interfaces
{
	public interface I_CombatInstance
	{
		# region Properties
		// Teams
		public List<Pokemon> TeamA { get; }
		public Pokemon ActiveA { get; }
		public List<Pokemon> TeamB { get; }
		public Pokemon ActiveB { get; }

		// Terrain Effects
		public Weather Weather { get; set; }
		# endregion

		# region Methods
		public bool executeTurn();
		# endregion
	}
}