using Pokedex.Interfaces;

namespace Pokedex.Models.Events
{
	class SwitchInputEvent : I_Event
	{
		# region Variables
		private Player _origin;
		private CombatInstance _context;
		# endregion

		# region Properties
		public int Priority { get => 0; }
		public int Speed { get => 0; }
		# endregion

		# region Constructor
		public SwitchInputEvent
		(
			Player origin,
			CombatInstance context
		)
		{
			this._origin = origin;
			this._context = context;
		}
		# endregion


		# region Methods
		public void PreUpdate() {}

		public void Update()
		{
			Console.WriteLine("Choose a pokemon to send");
			Console.WriteLine();

			// Print the available pokemons
			this._origin.Team
				.Where(poke => poke != this._origin.Active)
				.Where(poke => poke.HP > 0)
				.Select((poke, i) => (poke, i))
				.ToList()
				.ForEach(pair => Console.WriteLine($"{pair.i+1}: {pair.poke.QuickStatus}"));

			// Until a valid pokemon is chosen
			bool pokeChosen = false;
			while (!pokeChosen)
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
				if (pokeNum < 1 || pokeNum > this._origin.Team.Count)
				{
					Console.WriteLine("Invalid pokemon number");
					continue;
				}

				// Check if pokemon is not fainted
				if (this._origin.Team[pokeNum].CurrHP == 0)
				{
					Console.WriteLine("This pokémon is K.O.");
					continue;
				}

				this._origin.ChangeActive(pokeNum);
				Console.WriteLine($"{this._origin.Name} sends out {this._origin.Active.Nickname}");
				pokeChosen = true;
			}
		}
		# endregion
	}
}