using Pokedex.Interfaces;
using Pokedex.Models.Events;

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

		public I_Battler Active => Team[_activeIndex];

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
			Name = name;

			_activeIndex = 0;

			if (team.Count() >= 1 && team.Count() <= 6)
				Team = team;
			else throw new ArgumentException("Team must have between 1 and 6 Pokemon.");

			Team
				.ToList()
				.ForEach(poke => poke.Owner = this);

			Arena = arena;
		}
		#endregion

		#region Methods
		public void PlayTurn()
		{
			var endTurn = false;

			Active.Ability.OnTurnStart();

			// Until the player entered a command ending their turn
			// Or stdin is empty
			while (!endTurn
					&& Console.In.Peek() != -1)
			{
				// Read the command, and split it into words
				var action = Console.ReadLine()!
					.ToLower()
					.Split(' ');

				switch (action)
				{
					case ["status", string argWhat, "full" or "detailed"]:
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

			Active.Ability.OnTurnEnd();
		}

		/// <summary>
		/// Sub-method handling the <c>status ...</c> commands
		/// </summary>
		/// <param name="argWhat">The command parameter inputted by the player</param>
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
					OtherStatus();
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
			void SelfStatus(bool showDetail)
				=> Console.WriteLine(showDetail ? Active.GetFullStatus() : Active.GetQuickStatus());

			// Display the opponent's active pokemon's status
			void OtherStatus() =>
				Arena.Players
					.Where(player => player != this)
					.Select(player => player.Active)
					.ToList()
					.ForEach(poke => Console.WriteLine(poke.GetQuickStatus()));

			// Display the rest of the team statuses
			void BenchStatus(bool showDetail)
			{
				for (var i = 0; i < Team.Count(); i++)
				{
					if (i == _activeIndex) continue;

					string pokeStatus = showDetail
						? Team[i].GetFullStatus()
						: Team[i].GetQuickStatus();
					Console.WriteLine($"\x1b[38;2;255;127;0;1m{i+1}\x1b[0m {pokeStatus}");
				}

				if (Team.Count() == 1)
					Console.WriteLine("No pokemon on the bench");
			}

			// Display the active pokemon's moves
			void MoveStatus(bool showDetail)
			{
				for (var i = 0; i < 4; i++)
				{
					string moveStatus = showDetail
						? Active.Moves[i]?.GetFullStatus() ?? "---"
						: Active.Moves[i]?.GetQuickStatus() ?? "---";
					Console.WriteLine($"\x1b[38;2;255;127;0;1m{i+1}\x1b[0m {moveStatus}");
				}
			}
		}

		/// <summary>
		/// Sub-method handling the <c>move ...</c> commands
		/// </summary>
		/// <param name="argWhich">The command parameters inputted by the player</param>
		/// <param name="endTurn">Set to true if this action ends the turn</param>
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
			PokeMove? move = Active.Moves[moveNum - 1];
			// Check if a move is in that slot
			if (move == null)
			{
				Console.WriteLine("No move is in that slot");
				return;
			}

			// Create the event
			var ev = new MoveEvent(
				Active, this,
				move, Arena
			);
			// Add it to the queue
			Arena.AddToBottom(ev);

			// Conclude the player's turn
			endTurn = true;
		}

		/// <summary>
		/// Sub-method handling the <c>switch ...</c> commands
		/// </summary>
		/// <param name="argWhich">The command parameters inputted by the player</param>
		/// <param name="endTurn">Set to true if this action ends the turn</param>
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
			if (pokeNum < 1 || pokeNum > Team.Count())
			{
				Console.WriteLine("Invalid pokemon number");
				return;
			}

			// Check if 2nd arg is not already active pokemon
			if (pokeNum == _activeIndex)
			{
				Console.WriteLine("This pokemon is already on the field");
				return;
			}

			if (Team[pokeNum].CurrHP == 0)
			{
				Console.WriteLine("This pokémon is K.O.");
				return;
			}

			// Create the event
			var ev = new SwitchEvent(
				this, pokeNum,
				Arena
			);
			// Add it to the queue
			Arena.AddToBottom(ev);

			// Conclude the player's turn
			endTurn = true;
		}

		public void ChangeActive(int index)
		{
			Console.WriteLine($"\x1b[4m{Name} takes out {Active.Name}\x1b[0m");
			Console.WriteLine();
			Active.Ability.OnExit();

			_activeIndex = index;

			Console.WriteLine($"\x1b[4m{Name} sends out {Active.Name}\x1b[0m");
			Active.Ability.OnEnter();
		}

		public void AskActiveChange()
		{
			Console.WriteLine("\x1b[4m" + "Choose a pokemon to send" + "\x1b[0m");
			Console.WriteLine();

			// Print the available pokemons
			Team
				.Select((poke, i) => (poke, i))
				.Where(pair => pair.poke != Active)
				.Where(pair => pair.poke.CurrHP > 0)
				.ToList()
				.ForEach(pair => Console.WriteLine($"\x1b[38;2;255;127;0;1m{pair.i + 1}\x1b[0m: {pair.poke.GetQuickStatus()}"));

			Console.WriteLine();

			// Until a valid pokemon is chosen
			var pokeChosen = false;
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
				if (pokeNum < 1 || pokeNum > Team.Length)
				{
					Console.WriteLine("Invalid pokemon number");
					continue;
				}

				// Check if pokemon is not fainted
				if (Team[pokeNum].CurrHP == 0)
				{
					Console.WriteLine("This pokemon is K.O.");
					continue;
				}

				ChangeActive(pokeNum);
				pokeChosen = true;
			}
		}
		#endregion
	}
}