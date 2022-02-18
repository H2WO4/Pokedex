namespace Pokedex.Models.Weathers
{
	public class WeatherCloudy : Weather
	{
		# region Class Variables
		private static WeatherCloudy? _singleton;
		# endregion

		# region Properties
		public static WeatherCloudy Singleton { get => _singleton ?? (_singleton = new WeatherCloudy()); }
		# endregion

		# region Constructors
		protected WeatherCloudy() : base("Cloudy")
		{
			this._typePower.Add("Normal", 1f);
		}
		# endregion

		# region Methods
		public override float OnDamageGive(float damage, PokemonType type) =>
			this._typePower.GetValueOrDefault(type.Name, 0.75f) * damage;
		
		// Flavor Text
		public override void OnTurnStart(CombatInstance context) =>
			Console.WriteLine("The sky is cloudy.");
		public override void OnEnter() =>
			Console.WriteLine("The sky filled with clouds!");
		public override void OnExit() =>
			Console.WriteLine("The clouds disappeared.");

		# endregion
	}
}