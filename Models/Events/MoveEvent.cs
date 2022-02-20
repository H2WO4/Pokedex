using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	public class MoveEvent : I_Event
	{
		# region Variables
		protected Pokemon _caster;
		protected Player _origin;
		protected PokemonMove _move;
		protected CombatInstance _context;
		#endregion

		#region Properties
		public Pokemon Caster { get => this._caster; }
		public Player Origin { get => this._origin; }
		public PokemonMove Move { get => this._move; }
		public int Priority { get => this._move.Priority; }
		public int Speed { get => this._caster.Spd; }
		# endregion

		# region Constructors
		public MoveEvent
		(
			Pokemon origin,
			Player originPlayer,
			PokemonMove skill,
			CombatInstance context
		)
		{
			this._caster = origin;
			this._origin = originPlayer;
			this._move = skill;
			this._context = context;
		}
		# endregion

		# region Methods
		public void Update()
		{
			if (this._caster.CurrHP == 0)
				return;

			// Print move usage
			Console.WriteLine($"{this._caster.Nickname} uses {this._move.Name}");
			this._move.OnUse(this._caster, this._origin, this._context);
		}

		public void PreUpdate() => this._move.PreAction(this, this._context);
		#endregion
	}
}