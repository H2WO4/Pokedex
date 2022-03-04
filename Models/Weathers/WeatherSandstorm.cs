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
			this._typePower.Add("Rock", 1.5f);

			this._typeSelector.Add("Rock");
			this._typeSelector.Add("Steel");
			this._typeSelector.Add("Ground");
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
				Console.WriteLine($"{context.PlayerA.Active.Name} is buffeted by the sandstorm!");
				// Damage logic
			}

			if (context.PlayerB.Active.Types
					.Select(x => x.Name)
					.Intersect(this._typeSelector)
					.Count() == 0)
			{
				Console.WriteLine($"{context.PlayerB.Active.Name} is buffeted by the sandstorm!");
				// Damage logic
			}
		}

		// Flavor Text
		public override void OnTurnStart(CombatInstance context) =>
			Console.WriteLine("The sandstorm rages.");
		public override void OnEnter() =>
			Console.WriteLine("A sandstorm kicked up!");
		public override void OnExit() =>
			Console.WriteLine("The sandstorm subsided.");

		#endregion
	}
}