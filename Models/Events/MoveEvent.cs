using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	public class MoveEvent : I_Event
	{
		#region Variables
		protected Pokemon _caster;
		protected Player _origin;
		protected PokemonMove _move;
		protected CombatInstance _context;

		protected int _priority;
		protected int _speed;
		#endregion

		#region Properties
		public Pokemon Caster { get => this._caster; }
		public Player Origin { get => this._origin; }
		public PokemonMove Move { get => this._move; }
		public int Priority { get => this._priority; set => this._priority = value; }
		public int Speed { get => this._speed; set => this._speed = value; }
		#endregion

		#region Constructors
		public MoveEvent
		(
			Pokemon caster,
			Player origin,
			PokemonMove move,
			CombatInstance context
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
			Console.WriteLine("\x1b[4m" + $"{this._caster.Nickname} uses {this._move.Name}" + "\x1b[0m");
			this._move.OnUse(this._caster, this._origin, this._context);
		}

		public void PreUpdate() => this._move.PreAction(this, this._context);
		#endregion
	}
}