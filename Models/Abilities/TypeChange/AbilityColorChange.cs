using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities
{
	public class AbilityColorChange : Ability
	{
		#region Variables
		private PokeType? _tempType;
		#endregion

		#region Constructors
		public AbilityColorChange()
			: base("Color Change")
		{ }
		#endregion

		#region Methods
		// public override bool OnReceiveDamage(Interaction damage, I_Battler caster);

		public override List<PokeType>? ChangeType()
		{
			if (this._tempType != null)
				return new List<PokeType>(){ this._tempType };
			return null;
		}
		#endregion
	}
}