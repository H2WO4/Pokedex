namespace Pokedex.Models.Weathers
{
	public class WeatherAurora : Weather
	{
		#region Class Variables
		private static WeatherAurora? _singleton;
		#endregion

		#region Properties
		public static WeatherAurora Singleton { get => _singleton ?? (_singleton = new WeatherAurora()); }
		#endregion

		#region Constructors
		protected WeatherAurora() : base("Aurora Borealis")
		{
			this._typePower.Add("Fairy", 1.5f);
			this._typePower.Add("Dragon", 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(CombatInstance context) =>
			Console.WriteLine("The aurora borealis shines brightly.");
		public override void OnEnter() =>
			Console.WriteLine("An aurora borealis has appeared!");
		public override void OnExit() =>
			Console.WriteLine("The aurora borealis has disappeared.");

		#endregion
	}
}