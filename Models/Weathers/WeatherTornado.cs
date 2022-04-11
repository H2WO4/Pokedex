using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherTornado : Weather
	{
		#region Class Variables
		private static WeatherTornado? _singleton;
		#endregion

		#region Properties
		public static WeatherTornado Singleton => _singleton ??= new();
		#endregion

		#region Constructors
		private WeatherTornado() : base("Tornado")
		{
			TypePower.Add(TypeFlying.Singleton, 1.5f);
			TypePower.Add(TypeGround.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("Gusts of wind blow around the battlefield.");
		public override void OnEnter()
			=> Console.WriteLine("A tornado is raging.");
		public override void OnExit()
			=> Console.WriteLine("The tornado subsided.");

		#endregion
	}
}