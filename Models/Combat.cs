using System.Linq;
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
		public I_Player[] Players => new[] { _playerA, _playerB };

		public LinkedList<I_Event> EventQueue { get; set; }

		public Weather Weather
		{
			get => _weather;
			set
			{
				_weather.OnExit();
				_weather = value;
				_weather.OnEnter();
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
			_turn = 0;

			_playerA = new Trainer(playerA.name, playerA.team, this);
			_playerB = new Trainer(playerB.name, playerB.team, this);

			_weather = WeatherClear.Singleton;
			EventQueue = new LinkedList<I_Event>();
		}
		#endregion

		#region Methods
		public void AddToBottom(I_Event ev)
			=> EventQueue.AddLast(ev);

		public void AddToTop(I_Event ev)
			=> EventQueue.AddFirst(ev);

		public I_Player? DoTurn()
		{
			while (Console.In.Peek() != -1)
			{
				// Display turn
				_turn++;
				Console.WriteLine($"\x1b[1;4mTurn {_turn}\x1b[0m");
				// Display weather
				_weather.OnTurnStart(this);

				Console.WriteLine();

				// * Take input from players
				Console.WriteLine($"\x1b[4mIt's {_playerA.Name}'s turn!\x1b[0m");
				Console.WriteLine();
				_playerA.PlayTurn();

				// Console.Clear();

				Console.WriteLine($"\x1b[4mIt's {_playerB.Name}'s turn!\x1b[0m");
				Console.WriteLine();
				_playerB.PlayTurn();

				// * Handles the event queue
				EventQueue
					.ToList()
					.ForEach(ev => ev.PreUpdate()); // Do actions that could reorder the queue

				EventQueue = new LinkedList<I_Event>(EventQueue
					.OrderByDescending(ev => (ev.Priority, ev.Speed))); // Put the higher priority events at the beginning

				// Do the events
				while (EventQueue.Count > 0)
				{
					I_Event next = EventQueue.First();

					EventQueue
						.RemoveFirst();

					next.Update();
				}

				// Do weather effects
				if (Players
				    .Select(player => player.Active)
				    .All(poke => poke.Ability.AllowWeather()))
					_weather.OnTurnEnd(this);
			}

			// Return the winning player
			return Players
				.First(player => player.Team.All(poke => poke.CurrHP > 0));
		}
		#endregion
	}
}