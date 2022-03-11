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
			Console.WriteLine("The swarm of locusts is swarming around.");
		public override void OnEnter() =>
			Console.WriteLine("Locusts are starting to swarm the area!");
		public override void OnExit() =>
			Console.WriteLine("The swarm of locusts has dispersed.");

		#endregion
	}
}