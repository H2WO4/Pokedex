using Pokedex.Interfaces;
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
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("Rain continues to fall.");
		public override void OnEnter()
			=> Console.WriteLine("Rain continues to fall.");
		public override void OnExit()
			=> Console.WriteLine("Rain continues to fall.");

		#endregion
	}
}