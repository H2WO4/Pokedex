using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherCloudy : Weather
	{
		#region Class Variables
		private static WeatherCloudy? _singleton;
		#endregion

		#region Properties
		public static WeatherCloudy Singleton { get => _singleton ?? (_singleton = new WeatherCloudy()); }
		#endregion

		#region Constructors
		protected WeatherCloudy() : base("Cloudy")
		{
			this._typePower.Add(TypeNormal.Singleton, 1f);
		}
		#endregion

		#region Methods
		public override double OnDamageGive(double damage, PokeType type) =>
			this._typePower.GetValueOrDefault(type, 0.75f) * damage;

		// Flavor Text
		public override void OnTurnStart(Combat context) =>
			Console.WriteLine("The sky is cloudy.");
		public override void OnEnter() =>
			Console.WriteLine("The sky filled with clouds!");
		public override void OnExit() =>
			Console.WriteLine("The clouds disappeared.");

		#endregion
	}
}