using Pokedex.Interfaces;
using Pokedex.Enums;
using Pokedex.Models.Weathers;

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

			this._weather = WeatherClear.Singleton;
			this._eventQueue = new List<I_Event>();
		}
		# endregion

		# region Methods
		public bool executeTurn()
		{
			var turnAOver = false;
			while (!turnAOver)
			{

				Console.WriteLine("Player A's turn");

				// Read the command
				string[] action = Console.ReadLine()!
					.ToLower()
					.Split(' ').ToArray();

				// Use a move
				if (action[0] == "move" && action.Length == 2)
				{
					PokemonMove? move = this._activeA.Moves.ToList().Find(x => x?.Name.ToLower() == action[1]);
					if (move != null)
					{
						this._eventQueue.Add(
							new SkillEvent(
								this._activeA, Team.TeamA,
								move, this
							)
						);
						turnAOver = true;
					}
					else Console.WriteLine("Invalid move");
				}

				// Switch the Pokémon
				else if (action[0] == "switch" && action.Length == 2)
				{
					Pokemon? pokemon = this._teamA.Find(x => x.Name.ToLower() == action[1]);
					if (pokemon != null)
					{
						this._eventQueue.Add(
							new SwitchEvent(
								Team.TeamA,
								pokemon, this
							)
						);
						turnAOver = true;
					}
					else Console.WriteLine("Invalid Pokémon");
				}
				
				// Error message
				else Console.WriteLine("Incorrect command");

				// Console.Clear();

			}

			var turnBOver = false;
			while (!turnBOver)
			{
				Console.WriteLine("Player B's turn");

				// Read the command
				string[] action = Console.ReadLine()!
					.ToLower()
					.Split(' ').ToArray();

				// Use a move
				if (action[0] == "move" && action.Length == 2)
				{
					PokemonMove? move = this._activeB.Moves.ToList().Find(x => x?.Name.ToLower() == action[1]);
					if (move != null)
					{
						this._eventQueue.Add(
							new SkillEvent(
								this._activeB, Team.TeamB,
								move, this
							)
						);
						turnBOver = true;
					}
					else Console.WriteLine("Invalid move");
				}

				// Switch the Pokémon
				else if (action[0] == "switch" && action.Length == 2)
				{
					Pokemon? pokemon = this._teamB.Find(x => x.Name.ToLower() == action[1]);
					if (pokemon != null)
					{
						this._eventQueue.Add(
							new SwitchEvent(
								Team.TeamB,
								pokemon, this
							)
						);
						turnBOver = true;
					}
					else Console.WriteLine("Invalid Pokémon");
				}
				
				// Error message
				else Console.WriteLine("Incorrect command");

				// Console.Clear();
			}

			return false;
		}
		# endregion
	}
}