using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherSilence : Weather
	{
		#region Class Variables
		private static WeatherSilence? _singleton;
		#endregion

		#region Properties
		public static WeatherSilence Singleton { get => _singleton ?? (_singleton = new WeatherSilence()); }
		#endregion

		#region Constructors
		protected WeatherSilence() : base("Silence")
		{
			this._typePower.Add(TypePsychic.Singleton, 1.5f);
			this._typePower.Add(TypeGhost.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("The battlefield is shrouded in silence.");
		public override void OnEnter()
			=> Console.WriteLine("The battlefield is shrouded in silence.");
		public override void OnExit()
			=> Console.WriteLine("The battlefield is shrouded in silence.");

		#endregion
	}
}