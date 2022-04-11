using Pokedex.Interfaces;

namespace Pokedex.Models.Abilities
{
	public class AbilityProtean : Models.Ability
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
		{
			Announce();
			_tempType = move.Type;
		}

		public override List<PokeType>? ChangeType()
			=> _tempType != null ? new List<PokeType>{ _tempType } : null;

		#endregion
	}
}