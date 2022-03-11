using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherSandstorm : Weather
	{
		#region Class Variables
		private static WeatherSandstorm? _singleton;
		#endregion

		#region Properties
		public static WeatherSandstorm Singleton { get => _singleton ?? (_singleton = new WeatherSandstorm()); }
		#endregion

		#region Constructors
		protected WeatherSandstorm() : base("Sandstorm")
		{
			this._typePower.Add(TypeRock.Singleton, 1.5f);

			this._typeSelector.Append(TypeRock.Singleton);
			this._typeSelector.Append(TypeSteel.Singleton);
			this._typeSelector.Append(TypeGround.Singleton);
		}
		#endregion

		#region Methods
		public override void OnTurnEnd(Combat context)
		{
			if (context.PlayerA.Active.Types
					.Intersect(this._typeSelector)
					.Count() == 0)
			{
				Console.WriteLine($"{context.PlayerA.Active.Name} is buffeted by the locust swarm!");
				// Damage logic
			}

			if (context.PlayerB.Active.Types
					.Intersect(this._typeSelector)
					.Count() == 0)
			{
				Console.WriteLine($"{context.PlayerB.Active.Name} is buffeted by the locust swarm!");
				// Damage logic
			}
		}

		// Flavor Text
		public override void OnTurnStart(Combat context) =>
			Console.WriteLine("The sandstorm rages.");
		public override void OnEnter() =>
			Console.WriteLine("A sandstorm kicked up!");
		public override void OnExit() =>
			Console.WriteLine("The sandstorm subsided.");

		#endregion
	}
}