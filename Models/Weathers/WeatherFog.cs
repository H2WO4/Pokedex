using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherFog : Weather
	{
		#region Class Variables
		private static WeatherFog? __singleton;
		#endregion

		#region Properties
		public static WeatherFog Singleton { get => __singleton ?? (__singleton = new WeatherFog()); }
		#endregion

		#region Constructors
		protected WeatherFog() : base("Fog")
		{
			this._typePower.Add(TypeGhost.Singleton, 1.5f);
			this._typePower.Add(TypeElectric.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("Fog swirls in the air.");
		public override void OnEnter()
			=> Console.WriteLine("Fog swirls around the battlefield!");
		public override void OnExit()
			=> Console.WriteLine("The fog clears away.");

		#endregion
	}
}