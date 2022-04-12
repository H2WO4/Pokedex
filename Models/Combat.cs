using Pokedex.Interfaces;
using Pokedex.Models.Weathers;

namespace Pokedex.Models;

/// <summary>
/// A 2-player fight
/// </summary>
public class Combat : I_Combat
{
	#region Variables
	private int _turn;
	private readonly I_Player _playerA;
	private readonly I_Player _playerB;

	private Weather _weather;
	#endregion

	#region Properties
	public I_Player[] Players => new[] { _playerA, _playerB };

	public LinkedList<I_Event> EventQueue { get; private set; } = new();

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
		(string name, I_Battler[] team) playerA,
		(string name, I_Battler[] team) playerB
	)
	{
		_turn = 0;

		_playerA = new Trainer(playerA.name, playerA.team, this);
		_playerB = new Trainer(playerB.name, playerB.team, this);

		_weather = WeatherClear.Singleton;
	}
	#endregion

	#region Methods
	public void AddToBottom(I_Event ev)
		=> EventQueue.AddLast(ev);

	public void AddToTop(I_Event ev)
		=> EventQueue.AddFirst(ev);

	public I_Player DoTurn()
	{
		while (Players.All(player => player.Team.Any(poke => poke.CurrHP > 0)))
		{
			// Display turn
			_turn++;
			Console.WriteLine($"Turn {_turn}");
			// Display weather
			_weather.OnTurnStart(this);

			Console.WriteLine();

			// Take input from players
			Console.WriteLine($"It's {_playerA.Name}'s turn!");
			Console.WriteLine();
			_playerA.PlayTurn();

			// Console.Clear();

			Console.WriteLine($"It's {_playerB.Name}'s turn!");
			Console.WriteLine();
			_playerB.PlayTurn();

			// Handles the event queue
			EventQueue.ToList()
				.ForEach(ev => ev.PreUpdate()); // Do actions that could reorder the queue

			// Put the higher priority events at the beginning, decide equalities based on speed
			EventQueue = new LinkedList<I_Event>(EventQueue
				.OrderByDescending(ev => (ev.Priority, ev.Speed)));
			
			// Do the events
			ExecuteEvents();

			// Do weather effects (if no ability blocks it)
			if (Players.All(player => player.Active.Ability.AllowWeather()))
				_weather.OnTurnEnd(this);
		}

		// Return the winning player (the one still standing)
		return Players
			.First(player => player.Team.Any(poke => poke.CurrHP > 0));
	}

	private void ExecuteEvents()
	{
		while (EventQueue.Any())
		{
			I_Event next = EventQueue.First();

			EventQueue.RemoveFirst();

			next.Update();
		}
	}

	#endregion
}