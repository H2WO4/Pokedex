using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherMidnight : Weather
	{
		#region Class Variables
		private static WeatherMidnight? __singleton;
		#endregion

		#region Properties
		public static WeatherMidnight Singleton { get => __singleton ?? (__singleton = new WeatherMidnight()); }
		#endregion

		#region Constructors
		protected WeatherMidnight() : base("Midnight")
		{
			this._typePower.Add(TypeDark.Singleton, 1.5f);
			this._typePower.Add(TypeLight.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("Moonlight shines through the night sky.");
		public override void OnEnter()
			=> Console.WriteLine("The moon is rising to its apex!");
		public override void OnExit()
			=> Console.WriteLine("The moon has set.");

		#endregion
	}
}