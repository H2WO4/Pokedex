using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	public class SwitchInputEvent : I_Event
	{
		#region Properties
		public int Priority => 0;
		public int Speed => 0;

		/// <summary>
		/// The player who initiated the switch
		/// </summary>
		public I_Player Origin { get; }

		/// <summary>
		/// In which combat the fight happens in
		/// </summary>
		protected I_Combat Context { get; }
		#endregion

		#region Constructor
		public SwitchInputEvent
		(
			I_Player origin,
			I_Combat context
		)
		{
			Origin = origin;
			Context = context;
		}
		#endregion

		#region Methods
		public void Update()
			=> Origin.AskActiveChange();

		public void PreUpdate() { }
		#endregion
	}
}