using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherThunderstorm : Weather
	{
		#region Class Variables
		private static WeatherThunderstorm? __singleton;
		#endregion

		#region Properties
		public static WeatherThunderstorm Singleton { get => __singleton ?? (__singleton = new WeatherThunderstorm()); }
		#endregion

		#region Constructors
		protected WeatherThunderstorm() : base("Thunderstorm")
		{
			this._typePower.Add(TypeElectric.Singleton, 1.5f);
			this._typePower.Add(TypeSteel.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("Lightning crackles in the sky.");
		public override void OnEnter()
			=> Console.WriteLine("A thunderstorm is brewing!");
		public override void OnExit()
			=> Console.WriteLine("The thunderstorm subsided.");

		#endregion
	}
}