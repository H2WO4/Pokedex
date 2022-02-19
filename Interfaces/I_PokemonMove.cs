using Pokedex.Models;
using Pokedex.Enums;

namespace Pokedex.Interfaces
{
	public interface I_PokemonMove
	{
		# region Properties
		string Name { get; }
		SkillClass Class { get; }
		int? Power { get; }
		int? Accuracy { get; }
		int MaxPP { get; }
		int PP { get; }
		int Priority { get; }
		PokemonType Type { get; }
		# endregion

		# region Methods
		void OnUse(Pokemon origin, List<Pokemon> targets, CombatInstance context);
		void PreAction(CombatInstance context);
		# endregion
	}
}