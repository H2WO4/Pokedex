using Pokedex.Interfaces;
using Pokedex.Models.Events;

namespace Pokedex.Models
{
	public class Player : I_Player
	{
		#region Variables
		private string _name;

		private int _activeIndex;
		private List<Pokemon> _team;

		private CombatInstance _context;
		#endregion

		#region Properties
		public string Name { get => this._name; }

		public Pokemon Active { get => this._team[this._activeIndex]; }
		public List<Pokemon> Team { get => this._team; }
		#endregion

		#region Constructors
		public Player(
			string name,
			List<Pokemon> team,
			CombatInstance context
		)
		{
			this._name = name;

			this._activeIndex = 0;

			if (team.Count >= 1 && team.Count <= 6)
				this._team = team;
			else throw new ArgumentException("Team must have between 1 and 6 Pokemon.");

			this._context = context;
		}
		#endregion

		#region Methods
		public int ChangeActive(int index) => this._activeIndex = index;

		public void PlayTurn()
		{
			bool endTurn = false;

			while (!endTurn && Console.In.Peek() != -1)
			{
				// Read the command
				string[] action = Console.ReadLine()!
					.ToLower()
					.Split(' ');

				if (action[0] == "")
					continue;

				// Depending on the first word
				switch (action[0])
				{
					case "status":
						this.StatusCommand(action);
						break;

					case "use":
						this.MoveCommand(action, out endTurn);
						break;

					case "switch":
						this.SwitchCommand(action, out endTurn);
						break;

					case "help":
						Console.WriteLine(string.Join('\n', new string[]{
							"- status [self | enemy | bench | moves] <full>",
							"- use [#move]",
							"- switch [#pokemon]",
						}));
						break;

					default:
						Console.WriteLine("Invalid command");
						break;
				}

				Console.WriteLine();
			}
		}

		private void StatusCommand(string[] action)
		{
			// Check if 2 or 3 args
			if (action.Count() != 2 && action.Count() != 3)
			{
				Console.WriteLine("Invalid number of arguments");
				return;
			}

			switch (action[1])
			{
				case "active":
				case "self":
					SelfStatus(action.ElementAtOrDefault(2));
					break;

				case "enemy":
				case "other":
					OtherStatus(action.ElementAtOrDefault(2));
					break;

				case "bench":
					BenchStatus(action.ElementAtOrDefault(2));
					break;

				case "move":
				case "moves":
					MoveStatus(action.ElementAtOrDefault(2));
					break;

				default:
					Console.WriteLine("Invalid parameter");
					break;
			}

			void SelfStatus(string? arg)
			{
				if (arg == "full" || arg == "detailed")
					Console.WriteLine(this.Active.GetFullStatus());

				else if (arg == null)
					Console.WriteLine(this.Active.GetQuickStatus());

				else
					Console.WriteLine("Invalid parameter");
			}

			void OtherStatus(string? arg)
			{
				if (arg != null)
				{
					Console.WriteLine("Invalid number of arguments");
					return;
				}

				if (this._context.PlayerA == this)
					Console.WriteLine(this._context.PlayerB.Active.GetQuickStatus());

				else
					Console.WriteLine(this._context.PlayerA.Active.GetQuickStatus());
			}

			void BenchStatus(string? arg)
			{
				if (arg == "full" || arg == "detailed")
					if (this._team.Count == 1)
						Console.WriteLine("No pokemon on the bench");
					else
						this._team
							.Select((poke, i) => (poke, i))
							.Where(pair => pair.poke != this.Active)
							.ToList()
							.ForEach(pair => Console.WriteLine($"\x1b[38;2;255;127;0;1m{pair.i + 1}\x1b[0m: {pair.poke.GetFullStatus()}"));

				else if (arg == null)
					if (this._team.Count == 1)
						Console.WriteLine("No pokemon on the bench");
					else
						this._team
							.Select((poke, i) => (poke, i))
							.Where(pair => pair.poke != this.Active)
							.ToList()
							.ForEach(pair => Console.WriteLine($"\x1b[38;2;255;127;0;1m{pair.i + 1}\x1b[0m: {pair.poke.GetQuickStatus()}"));

				else
					Console.WriteLine("Invalid parameter");
			}

			void MoveStatus(string? arg)
			{
				if (arg == "full" || arg == "detailed")
				{
					for (var i = 0; i < 4; i++)
						Console.WriteLine($"\x1b[38;2;255;127;0;1m{i + 1}\x1b[0m: {this.Active.Moves[i]?.GetFullStatus() ?? "Empty"}");
				}
				else if (arg == null)
				{
					for (var i = 0; i < 4; i++)
						Console.WriteLine($"\x1b[38;2;255;127;0;1m{i + 1}: {this.Active.Moves[i]?.GetQuickStatus() ?? "Empty"}");
				}
				else
					Console.WriteLine("Invalid parameter");
			}
		}

		private void MoveCommand(string[] action, out bool endTurn)
		{
			endTurn = false;

			// Check if 2 args
			if (action.Count() != 2)
			{
				Console.WriteLine("Invalid number of arguments");
				return;
			}

			int moveNum;
			// Check if 2nd arg is a number
			if (!Int32.TryParse(action[1], out moveNum))
			{
				Console.WriteLine("Second argument must be a number");
				return;
			}

			// Check if 2nd arg within 1-4
			if (moveNum < 1 || moveNum > 4)
			{
				Console.WriteLine("Invalid move number");
				return;
			}

			// Fetch the move
			PokemonMove? move = this.Active.Moves[moveNum - 1];
			// Check if a move is in that slot
			if (move == null)
			{
				Console.WriteLine("No move is in that slot");
				return;
			}

			// Create the event
			var ev = new MoveEvent(
				this.Active, this,
				move, this._context
			);
			// Add it to the queue
			this._context.AddToBottom(ev);

			// Conclude the player's turn
			endTurn = true;
		}

		private void SwitchCommand(string[] action, out bool endTurn)
		{
			endTurn = false;

			// Check if 2 args
			if (action.Count() != 2)
			{
				Console.WriteLine("Invalid number of arguments");
				return;
			}

			int pokeNum;
			// Check if 2nd arg is a number
			if (!Int32.TryParse(action[1], out pokeNum))
			{
				Console.WriteLine("Second argument must be a number");
				return;
			}
			pokeNum--; // Change from 1-based index to 0-based

			// Check if 2nd arg within bounds
			if (pokeNum < 1 || pokeNum > this._team.Count)
			{
				Console.WriteLine("Invalid pokemon number");
				return;
			}

			// Check if 2nd arg is not already active pokemon
			if (pokeNum == this._activeIndex)
			{
				Console.WriteLine("This pokemon is already on the field");
				return;
			}

			if (this._team[pokeNum].CurrHP == 0)
			{
				Console.WriteLine("This pokémon is K.O.");
				return;
			}

			// Create the event
			var ev = new SwitchEvent(
				this, pokeNum,
				this._context
			);
			// Add it to the queue
			this._context.AddToBottom(ev);

			// Conclude the player's turn
			endTurn = true;
		}

		#endregion
	}
}