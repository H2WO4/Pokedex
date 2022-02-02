using Pokedex.Interfaces;
using Pokedex.Enums;

namespace Pokedex.Models
{
	public class CombatInstance : I_CombatInstance
	{
		# region Variables
		// Teams
		private List<Pokemon> _teamA;
		private Pokemon _activeA;
		private List<Pokemon> _teamB;
		private Pokemon _activeB;
		
		private List<I_Event> _eventQueue;

		// Terrain Effects
		private Weather _weather;
		# endregion

		# region Properties
		// Teams
		public List<Pokemon> TeamA { get => this._teamA; }
		public Pokemon ActiveA { get => this._activeA; }
		public List<Pokemon> TeamB { get => this._teamB; }
		public Pokemon ActiveB { get => this._activeB; }

		// Terrain Effects
		public Weather Weather { get => this._weather; set => this._weather = value; }
		# endregion

		# region Constructors
		public CombatInstance(
			List<Pokemon> teamA,
			List<Pokemon> teamB
		)
		{
			if (teamA.Count <= 6)
			{
				this._activeA = teamA[0];
				this._teamA = teamA.TakeLast(teamA.Count - 1).ToList();
			}
			else throw new ArgumentException("Too many Pokemons in Team A");

			if (teamB.Count <= 6)
			{
				this._activeB = teamB[0];
				this._teamB = teamB.TakeLast(teamB.Count - 1).ToList();
			}
			else throw new ArgumentException("Too many Pokemons in Team B");

			this._weather = Weather.Clear;
			this._eventQueue = new List<I_Event>();
		}
		# endregion

		# region Methods
		public bool executeTurn()
		{
			var turnAOver = false;
			while (!turnAOver)
			{
				string[] action = Console.ReadLine()!.Split(' ');

				int num;
				if (action.Length == 2 && action[0] == "move" && int.TryParse(action[1], out num))
				{
					this._eventQueue.Add(new SkillEvent(this._activeA.Moves[num], ref this._eventQueue));
					turnAOver = true;
				}
				else if (action.Length == 2 && action[0] == "switch" && int.TryParse(action[1], out num))
				{
					if (num <= this._teamA.Count)
					{

					}
					else
						Console.WriteLine("Incorrect Pokémon");
				}
				else
					Console.WriteLine("Incorrect command");
			}

			return false;
		}
		# endregion
	}
}