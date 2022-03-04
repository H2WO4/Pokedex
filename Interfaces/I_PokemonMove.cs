using Pokedex.Enums;
using Pokedex.Models;
using Pokedex.Models.Events;

namespace Pokedex.Interfaces
{
	public interface I_PokemonMove
	{
		#region Properties
		string Name { get; }
		MoveClass Class { get; }
		int? Power { get; }
		int? Accuracy { get; }
		int MaxPP { get; }
		int PP { get; }
		int Priority { get; }
		PokemonType Type { get; }
		#endregion

		#region Methods
		void OnUse(Pokemon caster, Player origin, CombatInstance context);
		bool AccuracyCheck(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context);
		List<(Player player, Pokemon pokemon)> GetTargets(Pokemon caster, Player origin, CombatInstance context);
		void DoAction(Pokemon target, Player owner, Pokemon caster, Player origin, CombatInstance context);

		void PreAction(MoveEvent event_, CombatInstance context);
		#endregion
	}
}