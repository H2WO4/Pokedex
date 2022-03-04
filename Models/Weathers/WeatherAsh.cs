namespace Pokedex.Models.Weathers
{
	public class WeatherAsh : Weather
	{
		#region Class Variables
		private static WeatherAsh? _singleton;
		#endregion

		#region Properties
		public static WeatherAsh Singleton { get => _singleton ?? (_singleton = new WeatherAsh()); }
		#endregion

		#region Constructors
		protected WeatherAsh() : base("Ash Cloud")
		{
			this._typePower.Add("Ground", 1.5f);
			this._typePower.Add("Flying", 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(CombatInstance context) =>
			Console.WriteLine("The sky is still shrouded in ash.");
		public override void OnEnter() =>
			Console.WriteLine("The sky is thick with ash!");
		public override void OnExit() =>
			Console.WriteLine("The thick ash has cleared away.");

		#endregion
	}
}