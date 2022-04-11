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
		public override bool OnReceiveDamage(DamageInfo dmgInfo, I_Battler caster)
		{
			if (dmgInfo.Type != null)
			{
				this.Announce();
				this._tempType = dmgInfo.Type;
			}

			return true;
		}

		public override List<PokeType>? ChangeType()
		{
			if (this._tempType != null)
				return new List<PokeType>(){ this._tempType };
			return null;
		}
		#endregion
	}
}