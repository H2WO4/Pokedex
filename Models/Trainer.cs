using Pokedex.Interfaces;
using Pokedex.Models.Events;

namespace Pokedex.Models
{
	/// <summary>
	/// Implements human-controlled player
	/// </summary>
	public class Trainer : I_Player
	{
		#region Variables
		private string _name;

		private int _activeIndex;
		private Pokemon[] _team;

		private Combat _arena;
		#endregion

		#region Properties
		/// <inheritdoc/>
		public string Name => this._name;

		/// <inheritdoc/>
		public Pokemon Active => this._team[this._activeIndex];

		/// <inheritdoc/>
		public Pokemon[] Team => this._team;

		/// <inheritdoc/>
		public I_Combat Arena => this._arena;
		#endregion

		#region Constructors
		public Trainer(
			string name,
			Pokemon[] team,
			Combat arena
		)
		{
			this._name = name;

			this._activeIndex = 0;

			if (team.Count() >= 1 && team.Count() <= 6)
				this._team = team;
			else throw new ArgumentException("Team must have between 1 and 6 Pokemon.");

			this.Team
				.ToList()
				.ForEach(poke => poke.Owner = this);

			this._arena = arena;
		}
		#endregion

		#region Methods
		/// <inheritdoc/>
		public void PlayTurn()
		{
			bool endTurn = false;

			// Until the player entered a command ending their turn
			// Or stdin is empty
			while (!endTurn && Console.In.Peek() != -1)
			{
				// Read the command, and split it into words
				string[] action = Console.ReadLine()!
					.ToLower()
					.Split(' ');

				// If nothing was entered, ignore
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
						Console.WriteLine("- status [self | enemy | bench | moves] <full>");
						Console.WriteLine("- use [#move]");
						Console.WriteLine("- switch [#pokemon]");
						break;

					// Incorrect command
					default:
						Console.WriteLine("Invalid command");
						break;
				}

				Console.WriteLine();
			}
		}

		/// <summary>
		/// Sub-method handling the <c>status ...</c> commands
		/// </summary>
		/// <param name="action">The command parameters inputed by the player</param>
		private void StatusCommand(string[] action)
		{
			// Check if 2 or 3 args
			if (action.Count() != 2 && action.Count() != 3)
			{
				Console.WriteLine("Invalid number of arguments");
				return;
			}

			// Depending on the second word
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

			// Display the active pokemon's status
			void SelfStatus(string? arg)
			{
				if (arg == "full" || arg == "detailed")
					Console.WriteLine(this.Active.GetFullStatus());

				else if (arg == null)
					Console.WriteLine(this.Active.GetQuickStatus());

				else
					Console.WriteLine("Invalid parameter");
			}

			// Display the opponent's active pokemon's status
			void OtherStatus(string? arg)
			{
				if (arg != null)
				{
					Console.WriteLine("Invalid number of arguments");
					return;
				}

				this._arena.Players
					.Where(player => player != this)
					.Select(player => player.Active)
					.ToList()
					.ForEach(poke => Console.WriteLine(poke.GetQuickStatus()));
			}

			// Display the rest of the team statuses
			void BenchStatus(string? arg)
			{
				if (arg == "full" || arg == "detailed")
					if (this._team.Count() == 1)
						Console.WriteLine("No pokemon on the bench");
					else
						this._team
							.Select((poke, i) => (poke, i))
							.Where(pair => pair.poke != this.Active)
							.ToList()
							.ForEach(pair => Console.WriteLine($"\x1b[38;2;255;127;0;1m{pair.i+1}\x1b[0m {pair.poke.GetFullStatus()}"));

				else if (arg == null)
					if (this._team.Count() == 1)
						Console.WriteLine("No pokemon on the bench");
					else
						this._team
							.Select((poke, i) => (poke, i))
							.Where(pair => pair.poke != this.Active)
							.ToList()
							.ForEach(pair => Console.WriteLine($"\x1b[38;2;255;127;0;1m{pair.i+1}\x1b[0m {pair.poke.GetQuickStatus()}"));

				else
					Console.WriteLine("Invalid parameter");
			}

			// Display the active pokemon's moves
			void MoveStatus(string? arg)
			{
				if (arg == "full" || arg == "detailed")
				{
					for (var i = 0; i < 4; i++)
						Console.WriteLine($"\x1b[38;2;255;127;0;1m{i+1}\x1b[0m {this.Active.Moves[i]?.GetFullStatus() ?? "---"}");
				}
				else if (arg == null)
				{
					for (var i = 0; i < 4; i++)
						Console.WriteLine($"\x1b[38;2;255;127;0;1m{i+1}\x1b[0m {this.Active.Moves[i]?.GetQuickStatus() ?? "---"}");
				}
				else
					Console.WriteLine("Invalid parameter");
			}
		}

		/// <summary>
		/// Sub-method handling the <c>move ...</c> commands
		/// </summary>
		/// <param name="action">The command parameters inputed by the player</param>
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
			PokeMove? move = this.Active.Moves[moveNum - 1];
			// Check if a move is in that slot
			if (move == null)
			{
				Console.WriteLine("No move is in that slot");
				return;
			}

			// Create the event
			var ev = new MoveEvent(
				this.Active, this,
				move, this._arena
			);
			// Add it to the queue
			this._arena.AddToBottom(ev);

			// Conclude the player's turn
			endTurn = true;
		}

		/// <summary>
		/// Sub-method handling the <c>switch ...</c> commands
		/// </summary>
		/// <param name="action">The command parameters inputed by the player</param>
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
			if (pokeNum < 1 || pokeNum > this._team.Count())
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
				this._arena
			);
			// Add it to the queue
			this._arena.AddToBottom(ev);

			// Conclude the player's turn
			endTurn = true;
		}

		/// <inheritdoc/>
		public void ChangeActive(int index) => this._activeIndex = index;

		/// <inheritdoc/>
		public void AskActiveChange()
		{
			Console.WriteLine("\x1b[4m" + "Choose a pokemon to send" + "\x1b[0m");
			Console.WriteLine();

			// Print the available pokemons
			this.Team
				.Select((poke, i) => (poke, i))
				.Where(pair => pair.poke != this.Active)
				.Where(pair => pair.poke.CurrHP > 0)
				.ToList()
				.ForEach(pair => Console.WriteLine($"\x1b[38;2;255;127;0;1m{pair.i + 1}\x1b[0m: {pair.poke.GetQuickStatus()}"));

			Console.WriteLine();

			// Until a valid pokemon is chosen
			bool pokeChosen = false;
			while (!pokeChosen && Console.In.Peek() != -1)
			{
				// Take input
				var input = Console.ReadLine();
				int pokeNum;

				// Check if arg is a number
				if (!Int32.TryParse(input, out pokeNum))
				{
					Console.WriteLine("Second argument must be a number");
					continue;
				}
				pokeNum--; // Change from 1-based index to 0-based

				// Check if arg within bounds
				if (pokeNum < 1 || pokeNum > this.Team.Count())
				{
					Console.WriteLine("Invalid pokemon number");
					continue;
				}

				// Check if pokemon is not fainted
				if (this.Team[pokeNum].CurrHP == 0)
				{
					Console.WriteLine("This pokémon is K.O.");
					continue;
				}

				Console.WriteLine("\x1b[4m" + $"{this.Name} takes out {this.Active.Name}" + "\x1b[0m");
				Console.WriteLine();
				this.ChangeActive(pokeNum);
				Console.WriteLine("\x1b[4m" + $"{this.Name} sends out {this.Active.Name}\n" + "\x1b[0m");
				pokeChosen = true;
			}
		}
		#endregion
	}
}