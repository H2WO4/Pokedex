namespace Pokedex.Models.Weathers
{
	public class WeatherMagnetic : Weather
	{
		#region Class Variables
		private static WeatherMagnetic? _singleton;
		#endregion

		#region Properties
		public static WeatherMagnetic Singleton { get => _singleton ?? (_singleton = new WeatherMagnetic()); }
		#endregion

		#region Constructors
		protected WeatherMagnetic() : base("Magnetic Storm")
		{
			this._typePower.Add("Steel", 1.5f);
			this._typePower.Add("Psychic", 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(CombatInstance context) =>
			Console.WriteLine("Magnetic waves pulsate through the air.");
		public override void OnEnter() =>
			Console.WriteLine("The magnetic current has been disrupted!");
		public override void OnExit() =>
			Console.WriteLine("The magnetic current went back to normal.");

		#endregion
	}
}