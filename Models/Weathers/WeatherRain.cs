using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherRain : Weather
	{
		#region Class Variables
		private static WeatherRain? _singleton;
		#endregion

		#region Properties
		public static WeatherRain Singleton { get => _singleton ?? (_singleton = new WeatherRain()); }
		#endregion

		#region Constructors
		protected WeatherRain() : base("Rain")
		{
			this._typePower.Add(TypeWater.Singleton, 1.5f);
			this._typePower.Add(TypeFire.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(Combat context) =>
			Console.WriteLine("Rain continues to fall.");
		public override void OnEnter() =>
			Console.WriteLine("It started to rain!");
		public override void OnExit() =>
			Console.WriteLine("The rain stopped.");

		#endregion
	}
}