using Pokedex.Models;
using Pokedex.Enums;

namespace Pokedex.Interfaces
{
	public interface I_PokemonSkill
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
		public void OnUse(Pokemon user, List<Pokemon> targets, List<PokemonSkill> skillQueue);
		# endregion
	}
}