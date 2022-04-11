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
		public static WeatherRainbow Singleton => _singleton ??= new();
		#endregion

		#region Constructors
		private WeatherRainbow() : base("Rainbow")
		{
			TypePower.Add(TypeLight.Singleton, 1.5f);
			TypePower.Add(TypeDark.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("The rainbow shines.");
		public override void OnEnter()
			=> Console.WriteLine("A rainbow appeared.");
		public override void OnExit()
			=> Console.WriteLine("The rainbow disappeared.");

		#endregion
	}
}