using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherRainbow : Weather
	{
		#region Class Variables
		private static WeatherRainbow? _singleton;
		#endregion

		#region Properties
		public static WeatherRainbow Singleton { get => _singleton ?? (_singleton = new WeatherRainbow()); }
		#endregion

		#region Constructors
		protected WeatherRainbow() : base("Rainbow")
		{
			this._typePower.Add(TypeLight.Singleton, 1.5f);
			this._typePower.Add(TypeDark.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("The rainbow shines.");
		public override void OnEnter()
			=> Console.WriteLine("The rainbow shines.");
		public override void OnExit()
			=> Console.WriteLine("The rainbow shines.");

		#endregion
	}
}