using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	class SwitchEvent : I_Event
	{
		#region Variables
		private Trainer _origin;
		private int _target;
		private Combat _context;
		#endregion

		#region Properties
		public Trainer Origin { get => this._origin; }
		public int Priority { get => 6; }
		public int Speed { get => 0; }
		#endregion

		#region Constructors
		public SwitchEvent
		(
			Trainer originPlayer,
			int target,
			Combat context
		)
		{
			this._origin = originPlayer;
			this._target = target;
			this._context = context;
		}
		#endregion

		#region Methods
		public void Update()
		{
			if (this._origin.Active.CurrHP == 0)
				return;

			Console.WriteLine("\x1b[4m" + $"{this._origin.Name} takes out {this._origin.Active.Name}" + "\x1b[0m");
			// ? Handles OnExit abilities
			this._origin.ChangeActive(this._target);
			Console.WriteLine("\x1b[4m" + $"{this._origin.Name} sends out {this._origin.Active.Name}" + "\x1b[0m");
			// ? Handles OnEnter abilities
		}
		
		public void PreUpdate() { }
		#endregion
	}
}