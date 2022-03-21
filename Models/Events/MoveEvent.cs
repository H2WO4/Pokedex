using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	public class MoveEvent : I_Event
	{
		#region Properties
		public int Priority { get; set; }
		public int Speed { get; set; }

		/// <summary>
		/// The Pokemon who used the move
		/// </summary>
		public I_Battler Caster { get; }

		/// <summary>
		/// The move used
		/// </summary>
		public PokeMove Move { get; }

		/// <summary>
		/// In which combat the fight happens in
		/// </summary>
		private I_Combat Context { get; }
		#endregion

		#region Constructors
		public MoveEvent
		(
			I_Battler caster,
			Trainer origin,
			PokeMove move,
			I_Combat context
		)
		{
			this.Caster = caster;
			this.Move = move;
			this.Context = context;

			this.Priority = move.Priority;
			this.Speed = caster.Spd();
		}
		#endregion

		#region Methods
		public void Update()
		{
			if (this.Caster.CurrHP == 0)
				return;

			// Print move usage
			Console.WriteLine("\x1b[4m" + $"{this.Caster.Name} uses {this.Move.Name}" + "\x1b[0m");
			this.Move.OnUse();
		}

		public void PreUpdate() => this.Move.PreAction(this);
		#endregion
	}
}