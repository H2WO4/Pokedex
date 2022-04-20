using Pokedex.Interfaces;
using Pokedex.Models.Weathers;


namespace Pokedex.Models;

/// <summary>
/// A 2 player fight
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
	public IEnumerable<I_Player> Players
	{
		get
		{
			yield return _playerA;
			yield return _playerB;
		}
	}

	public LinkedList<I_Event> EventQueue { get; private set; } = new();

	public Weather Weather
	{
		get => _weather;
		set
		{
			if (_weather == value) return;

			Weather old = _weather;
			_weather.OnExit();
			_weather = value;
			_weather.OnEnter();

			foreach (I_Player player in Players)
				player.Active.Ability.OnWeatherChange(old, value);
		}
	}
	#endregion

	#region Constructors
	public Combat
	(
		I_Player playerA,
		I_Player playerB
	)
	{
		_turn = 0;

		_playerA = playerA;
		_playerB = playerB;

		playerA.Arena = this;
		playerA.Arena = this;

		_weather = WeatherClear.Singleton;
	}
	#endregion

	#region Methods
	public void AddToBottom(I_Event ev)
		=> EventQueue.AddLast(ev);

	public void AddToTop(I_Event ev)
		=> EventQueue.AddFirst(ev);

	public I_Player DoCombat()
	{
		I_Battler[] allPokemons =
			Players.SelectMany(player => player.Team)
				   .ToArray();

		// Activate all end of combat abilities, across all pokemons
		foreach (I_Battler poke in allPokemons)
			poke.Ability.OnCombatStart();

		// While all players can fight, give them a turn
		while (Players.All(player => player.Team.Any(poke => poke.CurrHP > 0)))
			DoTurns();

		// Activate all end of combat abilities, across all pokemons
		foreach (I_Battler poke in allPokemons)
			poke.Ability.OnCombatEnd();

		// Return the winning player (the one still standing)
		return Players.First(player => player.Team
											 .Any(poke => poke.CurrHP > 0));
	}

	private void DoTurns()
	{
		// Display turn
		_turn++;
		Console.WriteLine($"Turn {_turn}");

		// Display weather
		Weather.OnTurnStart(this);

		// Activate abilities
		foreach (I_Player player in Players)
			player.Active.Ability.OnTurnStart();

		// Activate status effects
		IEnumerable<StatusEffect> effects =
			Players.Select(player => player.Active)
				   .SelectMany(active => active.StatusEffects);

		foreach (StatusEffect effect in effects)
			effect.OnTurnStart();

		Console.WriteLine();

		// Take input from players
		foreach (I_Player player in Players)
		{
			Console.WriteLine($"It's {player.Name}'s turn!");
			Console.WriteLine();
			player.PlayTurn();

			// Console.Clear();
		}

		// Do actions that could reorder the queue
		foreach (I_Event ev in EventQueue)
			ev.PreUpdate();

		// Put the higher priority events at the beginning, decide equalities based on speed
		EventQueue = new LinkedList<I_Event>(EventQueue.OrderByDescending(ev => (ev.Priority, ev.Speed)));

		// Do the events
		ExecuteEvents();

		// Do weather effects (if no ability blocks it)
		if (Players.All(player => player.Active.Ability.AllowWeather))
			Weather.OnTurnEnd(this);

		// Activate abilities
		foreach (I_Player player in Players)
			player.Active.Ability.OnTurnStart();

		// Activate status effects
		effects = Players.Select(player => player.Active)
						 .SelectMany(active => active.StatusEffects);

		foreach (StatusEffect effect in effects)
			effect.OnTurnEnd();
	}

	private void ExecuteEvents()
	{
		// While the event queue is not empty
		while (EventQueue.Any())
		{
			// Take the first event
			I_Event next = EventQueue.First();

			// Remove it from the queue
			EventQueue.RemoveFirst();

			// Execute it
			next.Update();
		}
	}
	#endregion
}