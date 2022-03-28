using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models
{
	/// <summary>
	/// A 2-player fight
	/// </summary>
	public class Combat : I_Combat
	{
		#region Variables
		private int _turn;
		private I_Player _playerA;
		private I_Player _playerB;

		private Weather _weather;
		#endregion

		#region Properties
		public I_Player[] Players => new[] { this._playerA, this._playerB };

		public LinkedList<I_Event> EventQueue { get; set; }

		public Weather Weather
		{
			get => this._weather;
			set
			{
				this._weather.OnExit();
				this._weather = value;
				this._weather.OnEnter();
			}
		}
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
			this.EventQueue = new LinkedList<I_Event>();
		}
		#endregion

		#region Methods
		public void AddToBottom(I_Event ev)
			=> this.EventQueue.AddLast(ev);

		public void AddToTop(I_Event ev)
			=> this.EventQueue.AddFirst(ev);

		public I_Player? DoTurn()
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
				this.EventQueue
					.ToList()
					.ForEach(ev => ev.PreUpdate()); // Do actions that could reorder the queue

				this.EventQueue = new LinkedList<I_Event>(this.EventQueue
					.OrderByDescending(ev => (ev.Priority, ev.Speed))); // Put the higher priority events at the beginning

				// Do the events
				while (this.EventQueue.Count > 0)
				{
					I_Event next = this.EventQueue.First();

					this.EventQueue
						.RemoveFirst();

					next.Update();
				}

				// Do weather effects
				if (this.Players
						.Select(player => player.Active)
						.All(poke => poke.Ability.AllowWeather()))
					this._weather.OnTurnEnd(this);
			}

			// Return the winning player
			return this.Players
				.Where(player => player.Team.All(poke => poke.CurrHP > 0))
				.FirstOrDefault();
		}
		#endregion
	}
}