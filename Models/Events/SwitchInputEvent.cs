using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	class SwitchInputEvent : I_Event
	{
		#region Variables
		private I_Player _origin;
		private I_Combat _context;
		#endregion

		#region Properties
		public int Priority { get => 0; }
		public int Speed { get => 0; }
		#endregion

		#region Constructor
		public SwitchInputEvent
		(
			I_Player origin,
			I_Combat context
		)
		{
			this._origin = origin;
			this._context = context;
		}
		#endregion

		#region Methods
		public void Update()
			=> this._origin.AskActiveChange();

		public void PreUpdate() { }
		#endregion
	}
}