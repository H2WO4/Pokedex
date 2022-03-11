using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherLocust : Weather
	{
		#region Class Variables
		private static WeatherLocust? _singleton;
		#endregion

		#region Properties
		public static WeatherLocust Singleton { get => _singleton ?? (_singleton = new WeatherLocust()); }
		#endregion

		#region Constructors
		protected WeatherLocust() : base("Locust Swarm")
		{
			this._typePower.Add(TypeBug.Singleton, 1.5f);

			this._typeSelector.Append(TypeBug.Singleton);
			this._typeSelector.Append(TypePoison.Singleton);
			this._typeSelector.Append(TypeGrass.Singleton);
		}
		#endregion

		#region Methods
		public override void OnTurnEnd(I_Combat arena)
		{
			arena.Players
				.Select(player => player.Active)
				.Where(poke => poke.Types.Intersect(this._typeSelector).Count() > 0)
				.ToList()
				.ForEach(poke => Console.WriteLine($"{poke.Name} is buffeted by the locust swarm!"));
		}

		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("The swarm of locusts is swarming around.");
		public override void OnEnter()
			=> Console.WriteLine("The swarm of locusts is swarming around.");
		public override void OnExit()
			=> Console.WriteLine("The swarm of locusts is swarming around.");

		#endregion
	}
}