using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherZenith : Weather
	{
		#region Class Variables
		private static WeatherZenith? __singleton;
		#endregion

		#region Properties
		public static WeatherZenith Singleton { get => __singleton ?? (__singleton = new WeatherZenith()); }
		#endregion

		#region Constructors
		protected WeatherZenith() : base("Zenith")
		{
			this._typePower.Add(TypeFire.Singleton, 1.5f);
			this._typePower.Add(TypeWater.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("Bright sunlight washes over the battlefield.");
		public override void OnEnter()
			=> Console.WriteLine("The sun rises to its zenith!");
		public override void OnExit()
			=> Console.WriteLine("The sun has set.");

		#endregion
	}
}