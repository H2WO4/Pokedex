using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

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
			this._typePower.Add(TypeSteel.Singleton, 1.5f);
			this._typePower.Add(TypePsychic.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("Magnetic waves pulsate through the air.");
		public override void OnEnter()
			=> Console.WriteLine("Magnetic waves pulsate through the air.");
		public override void OnExit()
			=> Console.WriteLine("Magnetic waves pulsate through the air.");

		#endregion
	}
}