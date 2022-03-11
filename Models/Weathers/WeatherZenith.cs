using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherZenith : Weather
	{
		#region Class Variables
		private static WeatherZenith? _singleton;
		#endregion

		#region Properties
		public static WeatherZenith Singleton { get => _singleton ?? (_singleton = new WeatherZenith()); }
		#endregion

		#region Constructors
		protected WeatherZenith() : base("Zenith")
		{
			this._typePower.Add(TypeFire.Singleton, 1.5f);
			this._typePower.Add(TypeWater.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(Combat context) =>
			Console.WriteLine("Bright sunlight washes over the battlefield.");
		public override void OnEnter() =>
			Console.WriteLine("The sun has reached its zenith!");
		public override void OnExit() =>
			Console.WriteLine("The sun has set.");

		#endregion
	}
}