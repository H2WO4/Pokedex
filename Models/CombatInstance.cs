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
		
		private List<I_Event> _eventQueue;

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
		public CombatInstance(
			(string name, Pokemon active, List<Pokemon> bench) playerA,
			(string name, Pokemon active, List<Pokemon> bench) playerB
		)
		{
			this._playerA = new Player(playerA.name, playerA.active, playerA.bench, this);
			this._playerB = new Player(playerB.name, playerB.active, playerB.bench, this);

			this._weather = WeatherClear.Singleton;
			this._eventQueue = new List<I_Event>();
		}
		# endregion

		# region Methods
		public void AppendEvent(I_Event ev) =>
			this._eventQueue.Add(ev);

		public bool DoTurn()
		{
			Console.WriteLine($"It's {this._playerA.Name}'s turn!");
			this._playerA.PlayTurn();

			Console.WriteLine($"It's {this._playerB.Name}'s turn!");
			this._playerB.PlayTurn();

			return false;
		}
		# endregion
	}
}