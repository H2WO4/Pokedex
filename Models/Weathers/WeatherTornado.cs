using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherTornado : Weather
	{
		#region Class Variables
		private static WeatherTornado? __singleton;
		#endregion

		#region Properties
		public static WeatherTornado Singleton { get => __singleton ?? (__singleton = new WeatherTornado()); }
		#endregion

		#region Constructors
		protected WeatherTornado() : base("Tornado")
		{
			this._typePower.Add(TypeFlying.Singleton, 1.5f);
			this._typePower.Add(TypeGround.Singleton, 0.5f);
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