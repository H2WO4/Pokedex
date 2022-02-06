using Pokedex.Enums;
using Pokedex.Interfaces;

namespace Pokedex.Models
{
	class SwitchEvent : I_Event
	{
		# region Variables
		protected Team _originTeam;
		protected Pokemon _target;
		protected CombatInstance _context;
		# endregion

		# region Properties
		public Team OriginTeam { get => this._originTeam; }
		# endregion

		# region Constructors
		public SwitchEvent
		(
			Team originTeam,
			Pokemon target,
			CombatInstance context
		)
		{
			this._originTeam = originTeam;
			this._target = target;
			this._context = context;
		}
		# endregion

		# region Methods
		public void Update()
		{
			throw new NotImplementedException();
		}
		# endregion
	}
}