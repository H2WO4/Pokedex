using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	public class SwitchEvent : I_Event
	{
		#region Properties
		public int Priority => 6;
		public int Speed => 0;

		/// <summary>
		/// The player who initiated the switch
		/// </summary>
		public Trainer Origin { get; }
		
		/// <summary>
		/// The Pokemon index to switch into
		/// </summary>
		/// <value></value>
		private int Target { get; }

		/// <summary>
		/// In which combat the fight happens in
		/// </summary>
		private I_Combat Context { get; }

		#endregion

		#region Constructors
		public SwitchEvent
		(
			Trainer originPlayer,
			int target,
			I_Combat context
		)
		{
			this.Origin = originPlayer;
			this.Target = target;
			this.Context = context;
		}
		#endregion

		#region Methods
		public void Update()
		{
			if (this.Origin.Active.CurrHP == 0)
				return;

			Console.WriteLine("\x1b[4m" + $"{this.Origin.Name} takes out {this.Origin.Active.Name}" + "\x1b[0m");
			// ? Handles OnExit abilities
			this.Origin.ChangeActive(this.Target);
			Console.WriteLine("\x1b[4m" + $"{this.Origin.Name} sends out {this.Origin.Active.Name}" + "\x1b[0m");
			// ? Handles OnEnter abilities
		}
		
		public void PreUpdate() { }
		#endregion
	}
}