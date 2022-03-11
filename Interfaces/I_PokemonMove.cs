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
		PokeType Type { get; }
		#endregion

		#region Methods
		void OnUse(Pokemon caster, Trainer origin, Combat context);
		bool AccuracyCheck(Pokemon target, Trainer owner, Pokemon caster, Trainer origin, Combat context);
		List<(Trainer player, Pokemon pokemon)> GetTargets(Pokemon caster, Trainer origin, Combat context);
		void DoAction(Pokemon target, Trainer owner, Pokemon caster, Trainer origin, Combat context);

		void PreAction(MoveEvent event_, Combat context);
		#endregion
	}
}