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
			this._typePower.Add("Bug", 1.5f);

			this._typeSelector.Add("Bug");
			this._typeSelector.Add("Poison");
			this._typeSelector.Add("Grass");
		}
		#endregion

		#region Methods
		public override void OnTurnEnd(CombatInstance context)
		{
			if (context.PlayerA.Active.Types
					.Select(x => x.Name)
					.Intersect(this._typeSelector)
					.Count() == 0)
			{
				Console.WriteLine($"{context.PlayerA.Active.Name} is buffeted by the locust swarm!");
				// Damage logic
			}

			if (context.PlayerB.Active.Types
					.Select(x => x.Name)
					.Intersect(this._typeSelector)
					.Count() == 0)
			{
				Console.WriteLine($"{context.PlayerB.Active.Name} is buffeted by the locust swarm!");
				// Damage logic
			}
		}

		// Flavor Text
		public override void OnTurnStart(CombatInstance context) =>
			Console.WriteLine("The swarm of locusts is swarming around.");
		public override void OnEnter() =>
			Console.WriteLine("Locusts are starting to swarm the area!");
		public override void OnExit() =>
			Console.WriteLine("The swarm of locusts has dispersed.");

		#endregion
	}
}