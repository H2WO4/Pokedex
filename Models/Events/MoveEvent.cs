using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	public class MoveEvent : I_Event
	{
		#region Variables
		private Pokemon _caster;
		private Trainer _origin;
		private PokemonMove _move;
		private Combat _context;

		private int _priority;
		private int _speed;
		#endregion

		#region Properties
		// Unique to MoveEvent
		public Pokemon Caster { get => this._caster; }
		public Trainer Origin { get => this._origin; }
		public PokemonMove Move { get => this._move; }

		public int Priority { get => this._priority; set => this._priority = value; }
		public int Speed { get => this._speed; set => this._speed = value; }
		#endregion

		#region Constructors
		public MoveEvent
		(
			Pokemon caster,
			Trainer origin,
			PokemonMove move,
			Combat context
		)
		{
			this._caster = caster;
			this._origin = origin;
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
			this._move.OnUse(this._caster, this._origin, this._context);
		}

		public void PreUpdate() => this._move.PreAction(this, this._context);
		#endregion
	}
}