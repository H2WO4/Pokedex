using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities
{
	public class AbilityProtean : Ability
	{
		#region Variables
		private PokeType? _tempType;
		#endregion

		#region Constructors
		public AbilityProtean()
			: base("Protean")
		{ }
		#endregion

		#region Methods
		public override void BeforeAttack(I_PokeMove move)
			=> this._tempType = move.Type;

		public override List<PokeType>? ChangeType()
		{
			if (this._tempType != null)
				return new List<PokeType>(){ this._tempType };
			return null;
		}
		#endregion
	}
}