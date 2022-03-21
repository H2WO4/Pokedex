using Pokedex.Interfaces;
using Pokedex.Models.Events;
using Pokedex.Models.Pokemons;

namespace Pokedex.Models
{
	/// <summary>
	/// Implements an human-controlled Player
	/// </summary>
	public class Trainer : I_Player
	{
		#region Variables
		private int _activeIndex;
		#endregion

		#region Properties
		public string Name { get; }

		public I_Battler Active => this.Team[this._activeIndex];

		public I_Battler[] Team { get; }

		public I_Combat Arena { get; }
		#endregion

		#region Constructors
		public Trainer(
			string name,
			I_Battler[] team,
			Combat arena
		)
		{
			this.Name = name;

			this._activeIndex = 0;

			if (team.Count() >= 1 && team.Count() <= 6)
				this.Team = team;
			else throw new ArgumentException("Team must have between 1 and 6 Pokemon.");

			this.Team
				.ToList()
				.ForEach(poke => poke.Owner = this);

			this.Arena = arena;
		}
		#endregion

		#region Methods
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

				switch (action)
				{
					case ["status", string argWhat, "full" or "detailled"]:
						StatusCommand(argWhat, true);
						break;

					case ["status", string argWhat]:
						StatusCommand(argWhat, false);
						break;
					
					case ["use", string argWhich]:
						MoveCommand(argWhich, out endTurn);
						break;
					
					case ["switch", string argWhich]:
						SwitchCommand(argWhich, out endTurn);
						break;
					
					case ["help"]:
						Console.WriteLine("- status [self | enemy | bench | moves] <full>");
						Console.WriteLine("- use [#move]");
						Console.WriteLine("- switch [#pokemon]");
						Console.WriteLine();
						break;
					
					case [""]:
						continue;
					
					default:
						Console.WriteLine("Invalid command");
						break;
				};

				Console.WriteLine();
			}
		}

		/// <summary>
		/// Sub-method handling the <c>status ...</c> commands
		/// </summary>
		/// <param name="argWhat">The command parameter inputed by the player</param>
		/// <param name="detail">Whether full details are asked</param>
		private void StatusCommand(string argWhat, bool detail)
		{

			// Depending on the second word
			switch (argWhat)
			{
				case "active" or "self":
					SelfStatus(detail);
					break;

				case "enemy" or "other" when !detail:
					OtherStatus(detail);
					break;

				case "bench":
					BenchStatus(detail);
					break;

				case "move" or "moves":
					MoveStatus(detail);
					break;

				default:
					Console.WriteLine("Invalid parameter");
					break;
			}

			// Display the active pokemon's status
			void SelfStatus(bool detail)
			{
				if (detail)
					Console.WriteLine(this.Active.GetFullStatus());
				else
					Console.WriteLine(this.Active.GetQuickStatus());
			}

			// Display the opponent's active pokemon's status
			void OtherStatus(bool detail)
			{
				this.Arena.Players
					.Where(player => player != this)
					.Select(player => player.Active)
					.ToList()
					.ForEach(poke => Console.WriteLine(poke.GetQuickStatus()));
			}

			// Display the rest of the team statuses
			void BenchStatus(bool detail)
			{
				for (var i = 0; i < this.Team.Count(); i++)
				{
					if (i == this._activeIndex) continue;

					string pokeStatus = detail
						? this.Team[i].GetFullStatus()
						: this.Team[i].GetQuickStatus();
					Console.WriteLine($"\x1b[38;2;255;127;0;1m{i+1}\x1b[0m {pokeStatus}");
				}

				if (this.Team.Count() == 1)
					Console.WriteLine("No pokemon on the bench");
			}

			// Display the active pokemon's moves
			void MoveStatus(bool detail)
			{
				for (var i = 0; i < 4; i++)
				{
					string moveStatus = detail
						? this.Active.Moves[i]?.GetFullStatus() ?? "---"
						: this.Active.Moves[i]?.GetQuickStatus() ?? "---";
					Console.WriteLine($"\x1b[38;2;255;127;0;1m{i+1}\x1b[0m {moveStatus}");
				}
			}
		}

		/// <summary>
		/// Sub-method handling the <c>move ...</c> commands
		/// </summary>
		/// <param name="argWhich">The command parameters inputed by the player</param>
		private void MoveCommand(string argWhich, out bool endTurn)
		{
			endTurn = false;

			int moveNum;
			// Check if arg is a number
			if (!Int32.TryParse(argWhich, out moveNum))
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
				move, this.Arena
			);
			// Add it to the queue
			this.Arena.AddToBottom(ev);

			// Conclude the player's turn
			endTurn = true;
		}

		/// <summary>
		/// Sub-method handling the <c>switch ...</c> commands
		/// </summary>
		/// <param name="argWhich">The command parameters inputed by the player</param>
		private void SwitchCommand(string argWhich, out bool endTurn)
		{
			endTurn = false;

			int pokeNum;
			// Check if 2nd arg is a number
			if (!Int32.TryParse(argWhich, out pokeNum))
			{
				Console.WriteLine("Second argument must be a number");
				return;
			}
			pokeNum--; // Change from 1-based index to 0-based

			// Check if 2nd arg within bounds
			if (pokeNum < 1 || pokeNum > this.Team.Count())
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

			if (this.Team[pokeNum].CurrHP == 0)
			{
				Console.WriteLine("This pokémon is K.O.");
				return;
			}

			// Create the event
			var ev = new SwitchEvent(
				this, pokeNum,
				this.Arena
			);
			// Add it to the queue
			this.Arena.AddToBottom(ev);

			// Conclude the player's turn
			endTurn = true;
		}

		public void ChangeActive(int index) => this._activeIndex = index;

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