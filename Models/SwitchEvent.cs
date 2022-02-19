using Pokedex.Interfaces;

namespace Pokedex.Models
{
	class SwitchEvent : I_Event
	{
		# region Variables
		protected Player _originPlayer;
		protected Pokemon _target;
		protected CombatInstance _context;
		# endregion

		# region Properties
		public Player OriginPlayer { get => this._originPlayer; }
		public int Priority { get => 6; }
		public int Speed { get => 0; }
		# endregion

		# region Constructors
		public SwitchEvent
		(
			Player originPlayer,
			Pokemon target,
			CombatInstance context
		)
		{
			this._originPlayer = originPlayer;
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