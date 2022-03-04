namespace Pokedex.Models.Weathers
{
	public class WeatherThunderstorm : Weather
	{
		#region Class Variables
		private static WeatherThunderstorm? _singleton;
		#endregion

		#region Properties
		public static WeatherThunderstorm Singleton { get => _singleton ?? (_singleton = new WeatherThunderstorm()); }
		#endregion

		#region Constructors
		protected WeatherThunderstorm() : base("Thunderstorm")
		{
			this._typePower.Add("Electric", 1.5f);
			this._typePower.Add("Steel", 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(CombatInstance context) =>
			Console.WriteLine("Lightning crackles in the sky.");
		public override void OnEnter() =>
			Console.WriteLine("A thunderstorm is brewing!");
		public override void OnExit() =>
			Console.WriteLine("The thunderstorm subsided.");

		#endregion
	}
}