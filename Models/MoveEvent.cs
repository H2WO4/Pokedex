using Pokedex.Interfaces;

namespace Pokedex.Models
{
	public class MoveEvent : I_Event
	{
		# region Variables
		protected Pokemon _origin;
		protected Player _originPlayer;
		protected PokemonMove _move;
		protected CombatInstance _context;
		#endregion

		#region Properties
		public Player OriginPlayer { get => this._originPlayer; }
		public int Priority { get => this._move.Priority; }
		public int Speed { get => this._origin.Spd; }
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
			this._origin = origin;
			this._originPlayer = originPlayer;
			this._move = skill;
			this._context = context;
		}
		# endregion

		# region Methods
		public void Update()
		{
			throw new NotImplementedException();
		}

		public void PreAction() => this._move.PreAction(this._context);
		#endregion
	}
}