using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	public class MoveEvent : I_Event
	{
		#region Variables
		private Pokemon _caster;
		private PokeMove _move;
		private Combat _context;

		private int _priority;
		private int _speed;
		#endregion

		#region Properties
		public Pokemon Caster { get => this._caster; }
		public PokeMove Move { get => this._move; }

		public int Priority { get => this._priority; set => this._priority = value; }
		public int Speed { get => this._speed; set => this._speed = value; }
		#endregion

		#region Constructors
		public MoveEvent
		(
			Pokemon caster,
			Trainer origin,
			PokeMove move,
			Combat context
		)
		{
			this._caster = caster;
			this._move = move;
			this._context = context;

			this._priority = move.Priority;
			this._speed = caster.Spd();
		}
		#endregion

		#region Methods
		public void Update()
		{
			if (this._caster.CurrHP == 0)
				return;

			// Print move usage
			Console.WriteLine("\x1b[4m" + $"{this._caster.Name} uses {this._move.Name}" + "\x1b[0m");
			this._move.OnUse();
		}

		public void PreUpdate() => this._move.PreAction(this);
		#endregion
	}
}