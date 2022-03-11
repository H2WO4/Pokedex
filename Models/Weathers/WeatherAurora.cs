using Pokedex.Interfaces;
using Pokedex.Models.PokemonTypes;

namespace Pokedex.Models.Weathers
{
	public class WeatherAurora : Weather
	{
		#region Class Variables
		private static WeatherAurora? _singleton;
		#endregion

		#region Properties
		public static WeatherAurora Singleton { get => _singleton ?? (_singleton = new WeatherAurora()); }
		#endregion

		#region Constructors
		protected WeatherAurora() : base("Aurora Borealis")
		{
			this._typePower.Add(TypeFairy.Singleton, 1.5f);
			this._typePower.Add(TypeDragon.Singleton, 0.5f);
		}
		#endregion

		#region Methods
		// Flavor Text
		public override void OnTurnStart(I_Combat arena)
			=> Console.WriteLine("The aurora borealis shines brightly.");
		public override void OnEnter()
			=> Console.WriteLine("The aurora borealis shines brightly.");
		public override void OnExit()
			=> Console.WriteLine("The aurora borealis shines brightly.");

		#endregion
	}
}