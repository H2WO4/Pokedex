using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models
{
	public class Combat : I_Combat
	{
		#region Variables
		private int _turn;
		// Teams
		private Trainer _playerA;
		private Trainer _playerB;

		private Queue<I_Event> _eventQueue;

		// Terrain Effects
		private Weather _weather;
		#endregion

		#region Properties
		// Players
		public Trainer PlayerA { get => this._playerA; }
		public Trainer PlayerB { get => this._playerB; }

		// System
		public Queue<I_Event> EventQueue { get => this._eventQueue; }

		// Terrain Effects
		public Weather Weather { get => this._weather; set => this._weather = value; }
		#endregion

		#region Constructors
		public Combat
		(
			(string name, Pokemon[] team) playerA,
			(string name, Pokemon[] team) playerB
		)
		{
			this._turn = 0;

			this._playerA = new Trainer(playerA.name, playerA.team, this);
			this._playerB = new Trainer(playerB.name, playerB.team, this);

			this._weather = WeatherClear.Singleton;
			this._eventQueue = new Queue<I_Event>();
		}
		#endregion

		#region Methods
		public void AddToBottom(I_Event ev) =>
			this._eventQueue.Enqueue(ev);

		public void AddToTop(I_Event ev) =>
			this._eventQueue = new Queue<I_Event>(this._eventQueue.Prepend(ev));

		public bool DoTurn()
		{
			while (Console.In.Peek() != -1)
			{
				// Display turn
				this._turn++;
				Console.WriteLine("\x1b[1;4m" + $"Turn {this._turn}" + "\x1b[0m");
				// Display weather
				this._weather.OnTurnStart(this);

				Console.WriteLine();

				// * Take input from players
				Console.WriteLine("\x1b[4m" + $"It's {this._playerA.Name}'s turn!" + "\x1b[0m");
				Console.WriteLine();
				this._playerA.PlayTurn();

				// Console.Clear();

				Console.WriteLine("\x1b[4m" + $"It's {this._playerB.Name}'s turn!" + "\x1b[0m");
				Console.WriteLine();
				this._playerB.PlayTurn();

				// * Handles the event queue
				this._eventQueue
					.ToList()
					.ForEach(ev => ev.PreUpdate()); // Do actions that could reorder the queue

				this._eventQueue = new Queue<I_Event>(this._eventQueue
					.OrderByDescending(ev => (ev.Priority, ev.Speed))); // Put the higher priority events at the beginning

				// Do the events
				while (this._eventQueue.Count > 0)
					this._eventQueue
						.Dequeue()
						.Update();

				// Do weather effects
				this._weather.OnTurnEnd(this);
			}

			// Return if PlayerA has remaining pokemons
			// AKA, return if PlayerA has won
			return this.PlayerA.Team.Any(poke => poke.HP() > 0);
		}
		#endregion
	}
}