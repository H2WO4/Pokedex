using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models
{
	public class CombatInstance : I_CombatInstance
	{
		# region Variables
		// Teams
		private Player _playerA;
		private Player _playerB;
		
		private Queue<I_Event> _eventQueue;

		// Terrain Effects
		private Weather _weather;
		# endregion

		# region Properties
		public Player PlayerA { get => this._playerA; }
		public Player PlayerB { get => this._playerB; }

		// Terrain Effects
		public Weather Weather { get => this._weather; set => this._weather = value; }
		# endregion

		# region Constructors
		public CombatInstance
		(
			(string name, List<Pokemon> team) playerA,
			(string name, List<Pokemon> team) playerB
		)
		{
			this._playerA = new Player(playerA.name, playerA.team, this);
			this._playerB = new Player(playerB.name, playerB.team, this);

			this._weather = WeatherClear.Singleton;
			this._eventQueue = new Queue<I_Event>();
		}
		# endregion

		# region Methods
		public void AddToBottom(I_Event ev) =>
			this._eventQueue.Enqueue(ev);
		
		public void AddToTop(I_Event ev) =>
			this._eventQueue = new Queue<I_Event>(this._eventQueue.Prepend(ev));

		public bool DoTurn()
		{
			while (Console.In.Peek() != -1)
			{
				// * Take input from players
				Console.WriteLine($"It's {this._playerA.Name}'s turn!");
				Console.WriteLine();
				this._playerA.PlayTurn();

				// Console.Clear();

				Console.WriteLine($"It's {this._playerB.Name}'s turn!");
				Console.WriteLine();
				this._playerB.PlayTurn();

				// * Handles the event queue
				this._eventQueue = new Queue<I_Event>(this._eventQueue
						.OrderByDescending(ev => (ev.Priority, ev.Speed))); // Put the higher priority events at the beginning
				
				this._eventQueue
					.ToList()
					.ForEach(ev => ev.PreUpdate()); // Do actions that could reorder the queue
				
				this._eventQueue = new Queue<I_Event>(this._eventQueue
					.OrderByDescending(ev => (ev.Priority, ev.Speed))); // Reorder the queue, as there could have been priority changes
				
				// Do the events
				while (this._eventQueue.Count > 0)
					this._eventQueue
						.Dequeue()
						.Update();
			}

			// Return if PlayerA has remaining pokemons
			// AKA, return if PlayerA has won
			return this.PlayerA.Team.Any(poke => poke.HP > 0);
		}
		# endregion
	}
}