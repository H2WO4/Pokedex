using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Abilities
{
	public class AbilityLevitate : Ability
	{
		#region Constructors
		public AbilityLevitate()
			: base("Levitate")
		{ }
		#endregion

		#region Methods
		// public override bool OnReceiveDamage(Interaction damage, I_Battler caster);
		#endregion
	}
}